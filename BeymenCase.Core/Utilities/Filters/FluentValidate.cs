using Microsoft.AspNetCore.Mvc.Filters;

using BeymenCase.Core.Models;
using BeymenCase.Core.Utilities.Exceptions;
using BeymenCase.Core.Utilities.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace BeymenCase.Core.Utilities
{
    public class FluentValidate : ActionFilterAttribute
    {
        private readonly Type _validatorType;
        public FluentValidate(Type type)
        {
            if (!typeof(IValidator).IsAssignableFrom(type))
                throw new BadRequestException(ResponseCode.Exception, "type is wrong");

            _validatorType = type;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = context.ActionArguments.Values.Where(t => t.GetType() == entityType);

            var messages = context.ModelState.Values
            .Where(x => x.ValidationState == ModelValidationState.Invalid)
            .SelectMany(x => x.Errors)
            .Select(x => x.ErrorMessage)
            .ToList();
            context.Result = new BadRequestObjectResult(messages);
            // foreach (var entity in entities)
            // {
            //     ValidationTool.Validate(validator, entity);
            // }
        }
    }
}