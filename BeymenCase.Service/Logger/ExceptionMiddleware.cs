using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BeymenCase.Service.Logger
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        static readonly ILogger Log = Serilog.Log.ForContext<ExceptionMiddleware>();
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var now = DateTime.UtcNow;
            Log.Error($"{now.ToString("HH:mm:ss")} : {ex}");
            return httpContext.Response.WriteAsync(new ErrorResultModel()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex.Message
            }.ToString());
        }
    }
}
