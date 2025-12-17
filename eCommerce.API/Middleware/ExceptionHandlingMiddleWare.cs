using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace eCommerce.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionHandlingMiddleWare(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ex.GetType().ToString()}:{ex.Message}");

                if(ex.InnerException is not null)
                {
                    _logger.LogError($"{ex.InnerException.GetType()}: {ex.InnerException.Message}");
                }

                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync(new { message = ex.Message, Type = ex.GetType().ToString() });
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddleWareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleWare>();
        }
    }
}
