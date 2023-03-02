using BeymenCase.Core.Models.Dtos.Setting;
using FluentValidation;

namespace SahaBT.Retro.Core.Validations.Agreements
{
    public class SettingUpdateDtoValidation :AbstractValidator<SettingUpdateDto>
    {
        public SettingUpdateDtoValidation()
        {
            // RuleFor(b => b.CurrencyType).NotEmpty().WithMessage(ValidationKey.NameNotNull);


        }
    }
}
