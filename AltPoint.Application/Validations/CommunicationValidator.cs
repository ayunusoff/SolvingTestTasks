using AltPoint.Application.DTOs.Request;
using AltPoint.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.Validations
{
    public class CommunicationValidator : AbstractValidator<CommunicationRequest>
    {
        public CommunicationValidator()
        {
            RuleFor(c => c.Type).IsInEnum();

            RuleFor(c => c.Value).NotNull();

            When(c => c.Type == CommunicationType.phone, () => RuleFor(c => c.Value).NotNull()); // TODO

            When(c => c.Type == CommunicationType.email, () => RuleFor(c => c.Value).EmailAddress().NotNull());
        }
    }
}
