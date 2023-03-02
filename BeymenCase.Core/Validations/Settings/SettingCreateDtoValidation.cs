using BeymenCase.Core.Models.Dtos.Setting;
using FluentValidation;

namespace SahaBT.Retro.Core.Validations.Agreements
{
    public class SettingCreateDtoValidation : AbstractValidator<SettingCreateDto>
    {
        public SettingCreateDtoValidation()
        {
            // RuleFor(b => b.CurrencyType).NotEmpty().WithMessage(ValidationKey.NameNotNull);

        }
        
    }
}
