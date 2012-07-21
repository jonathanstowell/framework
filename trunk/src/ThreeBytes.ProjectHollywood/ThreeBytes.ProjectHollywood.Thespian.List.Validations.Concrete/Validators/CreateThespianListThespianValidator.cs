using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Validations.Concrete.Validators
{
    public class CreateThespianListThespianValidator : AbstractValidator<ThespianListThespian>
    {
        public CreateThespianListThespianValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 35).WithMessage("'First Name' must be a string with a maximum length of 35.");
            RuleFor(x => x.LastName).NotEmpty().Length(1, 35).WithMessage("'Last Name' must be a string with a maximum length of 35.");
        }
    }
}
