using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SahaBT.Retro.Core.Utilities.Helpers;

namespace SahaBT.Retro.Core.Utilities
{
    public class DefaultResponseAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if(context.Result is not OkObjectResult)
                return;
                
            var value = ((OkObjectResult)context.Result)?.Value;

            var result = ResponseHelper.CreateDefaultResponse(value);

            context.Result = new JsonResult(result);
        }
    }
}