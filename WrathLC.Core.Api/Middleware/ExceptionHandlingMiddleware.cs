using System.Net;
using System.Security.Authentication;
using System.Text.Json;
using WrathLC.Core.Utility.Exceptions;
using WrathLC.Utility.Common.DataContracts.Models;

namespace WrathLC.Core.Api.Middleware;


public class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(ex, context);
        }
    }

    private async Task HandleExceptionAsync(Exception ex, HttpContext context)
    {
        var code = (int)HttpStatusCode.InternalServerError;
        var message = ex.Message;

        if (!_env.IsDevelopment())
        {
            message =
                "The system is temporarily unable to process your request. Please try again or contact an administrator.";
        }

        switch (ex)
        {
            case AuthenticationException:
                code = (int)HttpStatusCode.Unauthorized;
                message = "The user is not authenticated.";
                break;
            case UnauthorizedAccessException:
                code = (int)HttpStatusCode.Forbidden;
                message = "The user does not have access to the requested resource.";
                break;
            case InvalidOperationException:
            case ArgumentException:
                code = (int)HttpStatusCode.BadRequest;
                message = ex.Message;
                break;
            case KeyNotFoundException:
                code = (int)HttpStatusCode.NotFound;
                message = ex.Message;
                break;
            case ServerIsTeapotException:
                code = 418;
                message = ex.Message;
                break;
            case ResourceConflictException:
                code = (int)HttpStatusCode.Conflict;
                message = ex.Message;
                break;
            case NotImplementedException:
                code = (int)HttpStatusCode.NotImplemented;
                message = "Support for that type of request has not yet been fully implemented.";
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;
        var status = Enum.IsDefined(typeof(HttpStatusCode), code) ? ((HttpStatusCode)code).ToString() :
            code == 418 ? "ImATeapot" : "Unknown";
        var result = JsonSerializer.Serialize(new ExceptionModel()
        {
            Status = status,
            StatusCode = code,
            Message = message,
            StackTrace = _env.IsDevelopment() ? ex.StackTrace : null
        });
        await context.Response.WriteAsync(result);
    }
}