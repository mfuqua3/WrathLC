using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Core.Api.Middleware;
using WrathLC.Utility.Common.DataContracts.Models;

namespace WrathLC.Core.Api.Controllers.v1;

public class CoffeeController : ApiController
{
    /// <summary>
    /// Brews Coffee, provided that the server is able.
    /// </summary>
    /// <response code="201">The requested coffee.</response>
    /// <response code="418">If the server is a teapot.</response>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status418ImATeapot, Type = typeof(ExceptionModel))]
    public IActionResult BrewCoffee() => throw new ServerIsTeapotException();
}