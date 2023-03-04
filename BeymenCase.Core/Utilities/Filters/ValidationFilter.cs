using BeymenCase.Core.Models;
using BeymenCase.Core.Models.DataModels.ErrorModel;
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

                ValidationErrorResponse errorReponse = new ValidationErrorResponse();

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        ValidationErrorModel errorModel = new ValidationErrorModel
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