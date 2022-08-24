using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Core.Utility.DataContracts.Requests;
using WrathLC.Utility.Common.Constants;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Api.Controllers;

[ApiController]
[Area("api")]
[Route("[area]/v{version:apiVersion}/[controller]")]
[AllowAnonymous]
public abstract class ApiController : Controller
{
    protected T ForUser<T>(T request)
    where T: IUserId
    {
        request.UserId = "c5251822-ba41-4a8a-bd07-02512d872c40";
        return request;
        request.UserId = User.FindFirstValue(WrathLcClaims.Id);
        return request;
    }

    protected UserScopedRequest ForUser()
        => ForUser(new UserScopedRequest());
}