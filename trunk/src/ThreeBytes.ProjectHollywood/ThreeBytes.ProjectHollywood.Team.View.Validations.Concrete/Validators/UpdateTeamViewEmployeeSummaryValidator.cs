using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.View.Entities;

namespace ThreeBytes.ProjectHollywood.Team.View.Validations.Concrete.Validators
{
    public class UpdateTeamViewEmployeeSummaryValidator : AbstractValidator<TeamViewEmployee>
    {
        public UpdateTeamViewEmployeeSummaryValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
            RuleFor(x => x.Summary).NotEmpty();
        }
    }
}
