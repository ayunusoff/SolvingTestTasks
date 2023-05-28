using AltPoint.Application.DTOs.Request;
using AltPoint.Domain.Enums;
using FluentValidation;

namespace AltPoint.Application.Validations
{
    public class ClientValidator : AbstractValidator<ClientRequest>
    {
        public ClientValidator() 
        {
            RuleFor(c => c.MonExpences).GreaterThanOrEqualTo(0);

            RuleFor(c => c.MonIncome).GreaterThanOrEqualTo(0);

            RuleFor(c => c.LivingAddress).SetValidator(new AddressValidator()!);

            RuleFor(c => c.RegAddress).SetValidator(new AddressValidator()!);

            RuleForEach(c => c.Communications).SetValidator(new CommunicationValidator());

            RuleForEach(c => c.Jobs).SetValidator(new JobValidator());

            RuleFor(c => c.TypeEducation).IsInEnum();

        }
    }
}
