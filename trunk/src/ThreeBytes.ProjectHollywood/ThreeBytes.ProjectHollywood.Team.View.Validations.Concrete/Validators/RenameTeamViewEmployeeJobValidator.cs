using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.View.Entities;

namespace ThreeBytes.ProjectHollywood.Team.View.Validations.Concrete.Validators
{
    public class RenameTeamViewEmployeeJobValidator : AbstractValidator<TeamViewEmployee>
    {
        public RenameTeamViewEmployeeJobValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
            RuleFor(x => x.JobTitle).NotEmpty().Length(1, 50).WithMessage("'Job Title' must be a string with a maximum length of 50.");
        }
    }
}
