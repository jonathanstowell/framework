using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Concrete.Validators
{
    public class RenameThespianManagementThespianValidator : AbstractValidator<ThespianManagementThespian>
    {
        public RenameThespianManagementThespianValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Thespian does not exist");
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 35).WithMessage("'First Name' must be a string with a maximum length of 35.");
            RuleFor(x => x.LastName).NotEmpty().Length(1, 35).WithMessage("'Last Name' must be a string with a maximum length of 35.");
        }
    }
}