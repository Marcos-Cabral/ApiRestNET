using NETChallenge.Helpers;
using Newtonsoft.Json;

namespace NETChallenge.Middlewares
{
   public class ApiExceptionMiddleware
   {
        private readonly RequestDelegate _next;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var errorCodeStatus = HttpStatusCodeHelper.GetErrorCodeStatus(ex);
                await HandleExceptionAsync(context, ex, errorCodeStatus);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception ex, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = ResponseHelper.ArmarRespuestaErronea(ex.Message, statusCode);
            var json = JsonConvert.SerializeObject(response);
            await context.Response.WriteAsync(json);
        }
   }
}