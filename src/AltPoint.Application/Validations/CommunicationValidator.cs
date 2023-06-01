using AltPoint.Application.DTOs.Request;
using AltPoint.Domain.Enums;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AltPoint.Application.Validations
{
    public class CommunicationValidator : AbstractValidator<CommunicationRequest>
    {
        public CommunicationValidator()
        {
            When(c => c.Type == CommunicationType.phone, 
                () => RuleFor(c => c.Value)
                .NotEmpty()
                .MinimumLength(11)
                .MaximumLength(12)
                .Matches(new Regex(@"^((\+7|7|8)+([0-9]){10})$"))); 

            When(c => c.Type == CommunicationType.email, 
                () => RuleFor(c => c.Value)
                .NotEmpty()
                .EmailAddress()
                .NotNull());
        }
    }
}
