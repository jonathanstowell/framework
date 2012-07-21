using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Validations.Concrete.Validators
{
    public class DeleteThespianListThespianValidator : AbstractValidator<ThespianListThespian>
    {
        public DeleteThespianListThespianValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Thespian does not exist");
        }
    }
}