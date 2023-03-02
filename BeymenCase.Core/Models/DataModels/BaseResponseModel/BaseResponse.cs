using System.Net;

namespace BeymenCase.Core.Models
{
    public class BaseResponse<T> where T : class
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string HttpStatusCodeName => HttpStatusCode.ToString();
        public ResponseCode ResponseCode { get; set; }
        public string ResponseCodeName => ResponseCode.ToString();
        public string ExternalResponseCodeName { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}