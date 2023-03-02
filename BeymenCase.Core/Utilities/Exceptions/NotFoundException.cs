using BeymenCase.Core.Models;

namespace BeymenCase.Core.Utilities.Exceptions
{
    public class NotFoundException : HttpStatusException
    {
        public NotFoundException() : base(System.Net.HttpStatusCode.NotFound) { }
        public NotFoundException(string msg, Exception innerException = null) : base(System.Net.HttpStatusCode.NotFound, msg, innerException) { }
        public NotFoundException(ResponseCode errorCode) : base(System.Net.HttpStatusCode.NotFound, errorCode) { }
        public NotFoundException(ResponseCode errorCode, string msg, Exception innerException = null) : base(System.Net.HttpStatusCode.NotFound, errorCode, msg, innerException) { }
    }
}