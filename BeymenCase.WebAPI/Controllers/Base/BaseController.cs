using System;
using System.Security.Claims;
using BeymenCase.Core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeymenCase.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected BaseResponse<T> CreateDefaultResponse<T>(T data) where T : class
        {
            BaseResponse<T> response = new BaseResponse<T>
            {
                Data = data,
                ResponseCode = ResponseCode.Success,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };

            return response;
        }
    }
}
