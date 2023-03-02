using BeymenCase.Core.Models;
using BeymenCase.Core.Utilities.Exceptions;
using FluentValidation;

namespace BeymenCase.Core.Utilities.Validations
{
    public class ValidationTool
    {
        public static void Validate<T>(IValidator validator, T entity) where T : class, new()
        {
            var validationResult = validator.Validate(new ValidationContext<T>(entity));
            if (!validationResult.IsValid)
            {
                throw new BadRequestException(ResponseCode.ValidationException, string.Join(";", validationResult.Errors.Select(s=>s.ErrorMessage)));
            }
        }
    }
}