using System.Net;
using BeymenCase.Core.Models;

namespace BeymenCase.Utilities.Settings
{
     public static class DefaultError
    {
        public const HttpStatusCode DefaultHttpStatusCode = HttpStatusCode.InternalServerError;
        public const ResponseCode DefaultErrorCode = ResponseCode.Exception;
    }
}