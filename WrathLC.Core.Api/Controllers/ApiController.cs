using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Core.Utility.DataContracts.Requests;
using WrathLC.Utility.Common.Constants;
using WrathLC.Utility.Common.DataContracts.Interfaces;
using WrathLC.Utility.Common.DataContracts.Models;

namespace WrathLC.Core.Api.Controllers;

[ApiController]
[Area("api")]
[Route("[area]/v{version:apiVersion}/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public abstract class ApiController : Controller
{
    protected T ForUser<T>(T request)
    where T: IUserId
    {
        request.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return request;
    }

    protected UserScopedRequest ForUser()
        => ForUser(new UserScopedRequest());
}