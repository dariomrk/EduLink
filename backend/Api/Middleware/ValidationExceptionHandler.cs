using FluentValidation;
using System.Net;

namespace Api.Middleware;
public class ValidationExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ValidationExceptionHandler> _logger;

    public ValidationExceptionHandler(
        RequestDelegate next,
        ILogger<ValidationExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ValidationException ex)
        {
            _logger.LogInformation(ex, "{Caught validation exception `{ex}` with message: `{message}`}", ex, ex.Message);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var validationFailure = new
            {
                Errors = ex.Errors.Select(x => new
                {
                    PropertyName = x.PropertyName,
                    Detail = x.ErrorMessage,
                })
            };

            await httpContext.Response.WriteAsJsonAsync(validationFailure);
        }
    }
}
