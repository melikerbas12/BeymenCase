using BeymenCase.Core.Utilities.Exceptions;
using BeymenCase.Utilities.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BeymenCase.Business.Middlewares
{
    public class ExceptionHandlingMiddleware
     {
    //     private readonly RequestDelegate _next;
    //     private readonly ILogger _logger;

    //     public ExceptionHandlingMiddleware(RequestDelegate next, ILogger logger = null)
    //     {
    //         _next = next;
    //         _logger = logger;
    //     }

    //     public async Task Invoke(HttpContext context, ILogModel logModel, ILocalizationService localizationService)
    //     {
    //         try
    //         {
    //             await _next(context);
    //         }
    //         catch (Exception ex)
    //         {
    //             await HandleExceptionAsync(context, ex, logModel, localizationService);
    //         }
    //     }

    //     //ArgumentNullException
    //     private async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogModel logModel)
    //     {

    //         int code = (int)DefaultError.DefaultHttpStatusCode;

    //         if (exception is HttpStatusException ex)
    //             code = (int)ex.HttpStatusCode;

    //         if (exception is DbUpdateException)
    //             code = (int)HttpStatusCode.BadRequest;

    //         context.Response.StatusCode = code;

    //         var fileName = Utility.GetFileName(exception);
    //         var exceptionTypeName = Utility.GetExceptionTypeName(exception);
    //         var message = exception.Message;
    //         var stackTrace = exception.ToString();

    //         if (exception.InnerException != null)
    //         {
    //             message = string.Concat(message, CustomConstant.MESSAGE_SEPERATER, exception.InnerException?.Message);

    //             var innerFileName = Utility.GetFileName(exception.InnerException);
    //             var innerExceptionTypeName = Utility.GetExceptionTypeName(exception.InnerException);
    //             var innerMessage = exception.InnerException?.Message;
    //             var innerStackTrace = exception.InnerException?.ToString();

    //             logModel.AddedInnerException(innerFileName, innerExceptionTypeName, innerMessage, innerStackTrace);
    //         }

    //         var messageFromLocalization = await localizationService.GetLocalizationByCodeAsync(exception.Message, language);
    //         var result = new ErrorResponse(exception, messageFromLocalization);

    //         logModel.CompleteErrorLog(result, fileName, exceptionTypeName, message, stackTrace);

    //         _logger.Error(FileLogTitle.AuthLoggingMiddleware, 510, "ErrorWebApi", logModel);

    //         var options = new JsonSerializerOptions
    //         {
    //             IgnoreNullValues = true,
    //         };
    //         context.Response.ContentType = "application/json";
    //         await context.Response.WriteAsync(JsonSerializer.Serialize(result, options));
    //     }
    }
}