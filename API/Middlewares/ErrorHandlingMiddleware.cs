using System.Net;
using System.Text.Json;

namespace API.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly IHostEnvironment _env;
        public ErrorHandlingMiddleware(IHostEnvironment env)
        {
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            if (ex is ArgumentException || ex is InvalidOperationException)
            {
                code = HttpStatusCode.BadRequest;
            }
            else if (ex is KeyNotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }

            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                error = new
                {
                    message = ex.Message,
                    exception = ex.GetType().Name,
                    description = _env.IsDevelopment() ? ex.StackTrace?.ToString() : null
                }
            })).ConfigureAwait(false);
        }
    }

}
