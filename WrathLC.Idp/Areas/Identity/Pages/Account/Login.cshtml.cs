// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Discord.OAuth2;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WrathLc.Core.Data.Requests;
using WrathLc.Core.Managers.Manager.Components;
using WrathLc.Idp.ResourceAccess;

namespace WrathLc.Idp.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<WrathLcUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private IUserStore<WrathLcUser> _userStore;
        private UserManager<WrathLcUser> _userManager;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public LoginModel(SignInManager<WrathLcUser> signInManager,
            ILogger<LoginModel> logger,
            IUserStore<WrathLcUser> userStore,
            UserManager<WrathLcUser> userManager, IBackgroundJobClient backgroundJobClient)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userStore = userStore;
            _userManager = userManager;
            _backgroundJobClient = backgroundJobClient;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public IActionResult OnGetLoginDiscord(string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./Login", pageHandler: "Callback", values: new { returnUrl });
            var properties =
                _signInManager.ConfigureExternalAuthenticationProperties(DiscordDefaults.AuthenticationScheme,
                    redirectUrl);
            return new ChallengeResult(DiscordDefaults.AuthenticationScheme, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }
            
            var token = info.AuthenticationProperties.GetTokenValue("access_token");
            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
                isPersistent: true, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name,
                    info.LoginProvider);
                var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                _backgroundJobClient.Enqueue<IDiscordManager>(x =>
                    x.SyncUserAsync(new SyncUserRequest { UserId = user.Id, DiscordAccessToken = token }));
                return LocalRedirect(returnUrl);
            }

            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                // If the user does not have an account, then create one.
                ReturnUrl = returnUrl;
                var user = CreateUser();
                var username = info.Principal.FindFirstValue(ClaimTypes.Name);
                await _userStore.SetUserNameAsync(user, username, CancellationToken.None);
                var createResult = await _userManager.CreateAsync(user);
                if (!createResult.Succeeded)
                {
                    ErrorMessage = "Error creating user.";
                    return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
                }
                
                _backgroundJobClient.Enqueue<IDiscordManager>(x =>
                    x.SyncUserAsync(new SyncUserRequest { UserId = user.Id, DiscordAccessToken = token }));

                await _userManager.AddLoginAsync(user, info);
                await _signInManager.SignInAsync(user, true, info.LoginProvider);return LocalRedirect(returnUrl);
            }
        }

        private WrathLcUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<WrathLcUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(WrathLcUser)}'. " +
                                                    $"Ensure that '{nameof(WrathLcUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                    $"override the external login page in /Areas/Identity/Pages/Account/ExternalLogin.cshtml");
            }
        }
    }
}