using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BeymenCase.Core.Utilities
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                ErrorResponse errorReponse = new ErrorResponse();

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        ErrorModel errorModel = new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = subError
                        };

                        errorReponse.Errors.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorReponse);
            }
        }
    }
}

public class ErrorModel
{
    public string FieldName { get; set; }
    public string Message { get; set; }
}

public class ErrorResponse
{
    public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
}