using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Concrete.Validators
{
    public class DeleteThespianManagementThespianValidator : AbstractValidator<ThespianManagementThespian>
    {
        public DeleteThespianManagementThespianValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Thespian does not exist");
        }
    }
}