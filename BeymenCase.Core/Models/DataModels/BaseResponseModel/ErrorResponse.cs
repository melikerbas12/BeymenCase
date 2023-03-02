using BeymenCase.Core.Utilities.Exceptions;
using BeymenCase.Utilities.Settings;

namespace BeymenCase.Core.Models
{
    public class ErrorResponse : BaseResponse<object>
    {
        public ErrorResponse(Exception exception, string message = null)
        {
            Message = string.IsNullOrEmpty(message) ? exception.Message : message;

            if (exception is HttpStatusException ex)
            {
                HttpStatusCode = ex.HttpStatusCode;
                ResponseCode = ex.ResponseCode;
            }
            else
            {
                HttpStatusCode = DefaultError.DefaultHttpStatusCode;
                ResponseCode = DefaultError.DefaultErrorCode;
            }

            if (exception is ExternalHttpException external)
            {
                ExternalResponseCodeName = external._externalResponseCodeName;
            }
        }
    }
}