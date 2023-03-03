﻿using BeymenCase.Core.Keys;
using BeymenCase.Core.Models.Dtos.Setting;
using FluentValidation;

namespace BeymenCase.Core.Validations
{
    public class SettingUpdateDtoValidation : AbstractValidator<SettingUpdateDto>
    {
        public SettingUpdateDtoValidation()
        {
            RuleFor(b => b.Id).NotEmpty().WithMessage(ValidationKey.IdNotNull);
            RuleFor(b => b.Name).NotEmpty().WithMessage(ValidationKey.NameNotNull);
            RuleFor(b => b.Type).NotEmpty().WithMessage(ValidationKey.TypeNotNull);
            RuleFor(b => b.Value).NotEmpty().WithMessage(ValidationKey.ValueNotNull);
            RuleFor(b => b.ApplicationName).NotEmpty().WithMessage(ValidationKey.ApplicationNameNotNull);
        }
    }
}
