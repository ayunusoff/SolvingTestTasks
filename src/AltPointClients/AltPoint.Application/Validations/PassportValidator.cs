﻿using AltPoint.Application.DTOs;
using FluentValidation;

namespace AltPoint.Application.Validations
{
    public class PassportValidator : AbstractValidator<PassportDTO>
    {
        public PassportValidator()
        {
            RuleFor(p => p.Series).NotEmpty().Must(p => p.Length == 4);

            RuleFor(p => p.Number).NotEmpty().Must(p => p.Length == 6);

            RuleFor(p => p.Giver).NotEmpty();

            RuleFor(p => p.DateIssued).NotNull().NotEmpty();
        }
    }
}
