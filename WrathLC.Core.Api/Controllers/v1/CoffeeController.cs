using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Core.Api.Middleware;

namespace WrathLC.Core.Api.Controllers.v1;

public class CoffeeController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public IActionResult BrewCoffee() => throw new ServerIsTeapotException();
}