using AltPoint.Application.DTOs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AltPoint.Application.Validations
{
    public class JobValidator : AbstractValidator<JobDTO>
    {
        public JobValidator()
        {
            RuleFor(j => j.DateDismissal).GreaterThanOrEqualTo(j => j.DateEmp);

            RuleFor(j => j.MonIncome).NotEmpty().GreaterThanOrEqualTo(0);

            RuleFor(j => j.Type).NotEmpty().IsInEnum();

            RuleFor(j => j.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .Must(p => p.Length >= 11 && p.Length <= 12)
                .Matches(new Regex(@"^((\+7|7|8)+([0-9]){10})$"));

            RuleFor(j => j.JurAddress).SetValidator(new AddressValidator()!);
        }
    }
}
