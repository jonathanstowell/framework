using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Validations.Concrete.Validators
{
    public class DeleteThespianViewThespianValidator : AbstractValidator<ThespianViewThespian>
    {
        public DeleteThespianViewThespianValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Thespian does not exist");
        }
    }
}