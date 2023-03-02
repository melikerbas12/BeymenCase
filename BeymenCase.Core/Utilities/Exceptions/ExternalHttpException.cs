using BeymenCase.Core.Models;

namespace BeymenCase.Core.Utilities.Exceptions
{
    public class ExternalHttpException : HttpStatusException
    {
        public string _externalResponseCodeName { get; set; }
        public ExternalHttpException(string externalResponseCodeName) : base(System.Net.HttpStatusCode.NotFound) { _externalResponseCodeName = externalResponseCodeName; }
        public ExternalHttpException(string externalResponseCodeName, string msg, Exception innerException = null) : base(System.Net.HttpStatusCode.NotFound, msg, innerException) { _externalResponseCodeName = externalResponseCodeName; }
        public ExternalHttpException(ResponseCode errorCode, string externalResponseCodeName) : base(System.Net.HttpStatusCode.NotFound, errorCode) { _externalResponseCodeName = externalResponseCodeName; }
        public ExternalHttpException(ResponseCode errorCode, string externalResponseCodeName, string msg, Exception innerException = null) : base(System.Net.HttpStatusCode.NotFound, errorCode, msg, innerException) { _externalResponseCodeName = externalResponseCodeName; }
    }
}