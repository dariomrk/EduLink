using Application.Exceptions;
using System.Net;

namespace Api.Middleware
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandler> _logger;

        public CustomExceptionHandler(RequestDelegate next, ILogger<CustomExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) when (ex
                is IdentityException
                or InvalidRequestException
                or NotFoundException
                or NotSupportedException)
            {
                _logger.LogError(
                ex,
                "Caught exception `{ex}` with message: `{message}`.",
                ex,
                ex.Message);

                await HandleCustomExceptionAsync(ex, context);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(
                    ex,
                    "Caught fatal exception `{ex}` with message: `{message}`",
                    ex,
                    ex.Message);

                await HandleExceptionAsync(ex, context);
            }
        }

        private static async Task HandleCustomExceptionAsync(Exception ex, HttpContext context)
        {
            var statusCode = ex switch
            {
                IdentityException => HttpStatusCode.Forbidden,
                InvalidRequestException => HttpStatusCode.BadRequest,
                NotFoundException => HttpStatusCode.NotFound,
                NotSupportedException => HttpStatusCode.BadRequest,
                _ => throw new InvalidOperationException(),
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsJsonAsync(new
            {
                ex.Message,
            });
        }
        private static async Task HandleExceptionAsync(Exception ex, HttpContext context)
        {
            var statusCode = ex switch
            {
                NotImplementedException => HttpStatusCode.NotImplemented,
                _ => HttpStatusCode.InternalServerError,
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsJsonAsync(new
            {
                Message = "An internal server error occured.",
            });
        }
    }
}
