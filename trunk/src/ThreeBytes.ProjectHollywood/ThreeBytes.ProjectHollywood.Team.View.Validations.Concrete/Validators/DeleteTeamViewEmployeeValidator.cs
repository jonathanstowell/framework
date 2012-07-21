using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.View.Entities;

namespace ThreeBytes.ProjectHollywood.Team.View.Validations.Concrete.Validators
{
    public class DeleteTeamViewEmployeeValidator : AbstractValidator<TeamViewEmployee>
    {
        public DeleteTeamViewEmployeeValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
        }
    }
}