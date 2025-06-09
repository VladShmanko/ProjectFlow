using System.Net;
using System.Text.Json;

namespace ProjectFlow.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode >= 400 && context.Response.StatusCode < 600 && !context.Response.HasStarted)
                {
                    await HandleStatusCodeAsync(context, context.Response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = "An unexpected error occurred.",
                detail = ex.Message
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }

        private static async Task HandleStatusCodeAsync(HttpContext context, int statusCode)
        {
            context.Response.ContentType = "application/json";

            string message;

            switch (statusCode)
            {
                case (int)HttpStatusCode.NotFound:
                    message = "The requested resource was not found.";
                    break;
                case (int)HttpStatusCode.Unauthorized:
                    message = "Unauthorized access.";
                    break;
                case (int)HttpStatusCode.Forbidden:
                    message = "You do not have permission to access this resource.";
                    break;
                case (int)HttpStatusCode.BadRequest:
                    message = "Bad request.";
                    break;
                default:
                    message = "An error occurred.";
                    break;
            }

            var response = new
            {
                statusCode,
                message
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
