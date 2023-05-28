using AltPoint.Application.DTOs.Request;
using FluentValidation;

namespace AltPoint.Application.Validations
{
    public class JobValidator : AbstractValidator<JobRequest>
    {
        public JobValidator()
        {
            RuleFor(j => j.DateDismissal).GreaterThanOrEqualTo(j => j.DateEmp);

            RuleFor(j => j.MonIncome).GreaterThanOrEqualTo(0);

            RuleFor(j => j.Type).IsInEnum();

            RuleFor(j => j.PhoneNumber).NotNull(); // TODO

            RuleFor(j => j.JurAddress).SetValidator(new AddressValidator()!);
        }
    }
}
