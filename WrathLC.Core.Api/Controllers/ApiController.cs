using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WrathLC.Core.Api.Controllers;

[ApiController]
[Area("api")]
[Route("[area]/v{version:apiVersion}/[controller]")]
[Authorize]
public abstract class ApiController : Controller
{
    
}