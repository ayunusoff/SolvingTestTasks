using AltPoint.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltPoint.Application.Validations
{
    public class ClientWithSpouseValidator : AbstractValidator<ClientWithSpouseDTO>
    {
        public ClientWithSpouseValidator()
        {
            RuleFor(c => c.MonExpenses).GreaterThanOrEqualTo(0);

            RuleFor(c => c.MonIncome).GreaterThanOrEqualTo(0);

            RuleFor(c => c.TypeEducation).NotEmpty().IsInEnum();

            RuleFor(c => c.LivingAddress).SetValidator(new AddressValidator()!);

            RuleFor(c => c.RegAddress).SetValidator(new AddressValidator()!);

            RuleFor(c => c.Passport).SetValidator(new PassportValidator()!);

            RuleFor(c => c.Spouse).SetValidator(new SpouseValidator()!);

            RuleForEach(c => c.Communications).SetValidator(new CommunicationValidator());

            RuleForEach(c => c.Jobs).SetValidator(new JobValidator());
        }
    }
}
