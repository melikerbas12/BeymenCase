using BeymenCase.Core.Models;

namespace BeymenCase.Core.Utilities.Exceptions
{
    public class BadRequestException : HttpStatusException
    {
        public BadRequestException() : base(System.Net.HttpStatusCode.BadRequest) { }
        public BadRequestException(string msg, Exception innerException = null) : base(System.Net.HttpStatusCode.BadRequest, msg, innerException) { }
        public BadRequestException(ResponseCode errorCode) : base(System.Net.HttpStatusCode.BadRequest, errorCode) { }
        public BadRequestException(ResponseCode errorCode, string msg, Exception innerException = null) : base(System.Net.HttpStatusCode.BadRequest, errorCode, msg, innerException) { }
       // public BadRequestException(ResponseCode errorCode, List<string> msg, Exception innerException = null) : base(System.Net.HttpStatusCode.BadRequest, errorCode, msg, innerException) { }
    }
}