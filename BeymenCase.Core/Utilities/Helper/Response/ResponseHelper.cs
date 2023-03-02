using BeymenCase.Core.Models;

namespace SahaBT.Retro.Core.Utilities.Helpers
{
    public static class ResponseHelper
    {
        public static BaseResponse<T> CreateDefaultResponse<T>(T data) where T : class
        {
            BaseResponse<T> response = new BaseResponse<T>
            {
                Data = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };

            return response;
        }
    }
}