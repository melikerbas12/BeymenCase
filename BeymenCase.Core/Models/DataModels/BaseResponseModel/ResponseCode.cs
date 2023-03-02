using System;

namespace BeymenCase.Core.Models
{
    public enum ResponseCode : byte
    {
        Success = 0,
        Exception = 1,
        TokenException = 2,
        Unauthorized = 3,
        FileExceptions = 4,
        ExceptionSendMail = 5,
        ValidationException = 6,
        AuthException = 7,
        DatabaseException = 8,

    }
}
