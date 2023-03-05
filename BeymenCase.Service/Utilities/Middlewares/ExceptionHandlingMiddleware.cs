using BeymenCase.Core.Models;
using BeymenCase.Core.Utilities.Exceptions;
using BeymenCase.Utilities.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BeymenCase.Business.Middlewares
{
    public class ExceptionHandlingMiddleware
     {
         private readonly RequestDelegate _next;
         private readonly ILogger _logger;

         public ExceptionHandlingMiddleware(RequestDelegate next, ILogger logger)
         {
             _next = next;
             _logger = logger;
         }

         public async Task Invoke(HttpContext context)
         {
             try
             {
                 await _next(context);
             }
             catch (Exception ex)
             {
                 await HandleExceptionAsync(context, ex);
             }
         }

         //ArgumentNullException
         private async Task HandleExceptionAsync(HttpContext context, Exception exception)
         {

             int code = (int)DefaultError.DefaultHttpStatusCode;

             if (exception is HttpStatusException ex)
                 code = (int)ex.HttpStatusCode;

             if (exception is DbUpdateException)
                 code = (int)HttpStatusCode.BadRequest;

             context.Response.StatusCode = code;

             var message = exception.Message;
             var result = new ErrorResponse(exception, message);

             _logger.LogError("ErrorResponse: " + result, "Message: " + message);

             var options = new JsonSerializerOptions
             {
                 IgnoreNullValues = true,
             };
             context.Response.ContentType = "application/json";
             await context.Response.WriteAsync(JsonSerializer.Serialize(result, options));
             
         }
    }
}