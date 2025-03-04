using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace JobCode.Api.ExceptionHandlers;

public class ExceptionHandler(ILogger<ExceptionHandler> logger,
                                       IWebHostEnvironment env) : IExceptionHandler
{
    readonly ILogger<ExceptionHandler> _logger = logger;
    readonly IWebHostEnvironment _env = env;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Error: {Message}", exception.Message);

        var statusCode = exception switch
        {
            ArgumentNullException => StatusCodes.Status400BadRequest,
            KeyNotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };


        httpContext.Response.ContentType = "application/json";

        var isDevelotment = _env.IsDevelopment();

        var details = isDevelotment ? exception.StackTrace : "";

        var problemsDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = "Internal Server Error",
            Detail = details

        };

        httpContext.Response.StatusCode = problemsDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemsDetails, cancellationToken: cancellationToken);

        return true;
    }
}
