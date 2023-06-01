using AltPoint.Application.DTOs.Request;
using FluentValidation;

namespace AltPoint.Application.Validations
{
    public class ClientValidator : AbstractValidator<ClientRequest>
    {
        public ClientValidator() 
        {
            RuleFor(c => c.MonExpences).GreaterThanOrEqualTo(0);

            RuleFor(c => c.MonIncome).GreaterThanOrEqualTo(0);

            RuleFor(c => c.TypeEducation).NotEmpty().IsInEnum();

            RuleFor(c => c.LivingAddress).SetValidator(new AddressValidator()!);

            RuleFor(c => c.RegAddress).SetValidator(new AddressValidator()!);

            RuleFor(c => c.Passport).SetValidator(new PassportValidator()!);

            RuleForEach(c => c.Communications).SetValidator(new CommunicationValidator());

            RuleForEach(c => c.Jobs).SetValidator(new JobValidator());
        }
    }
}
