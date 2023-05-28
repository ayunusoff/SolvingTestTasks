using AltPoint.Application.DTOs.Response;
using FluentValidation;

namespace AltPoint.Application.Validations
{
    public class AddressValidator : AbstractValidator<AddressRequest>
    {
        public AddressValidator()
        {
            RuleFor(a => a.City).NotEmpty();

            RuleFor(a => a.Country).NotEmpty();

            RuleFor(a => a.Region).NotEmpty();

            RuleFor(a => a.House).NotEmpty();

            RuleFor(a => a.Street).NotEmpty();
        }
    }
}
