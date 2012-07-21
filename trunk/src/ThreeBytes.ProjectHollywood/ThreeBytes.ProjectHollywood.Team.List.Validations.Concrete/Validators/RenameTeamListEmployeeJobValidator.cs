using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.List.Entities;

namespace ThreeBytes.ProjectHollywood.Team.List.Validations.Concrete.Validators
{
    public class RenameTeamListEmployeeJobValidator : AbstractValidator<TeamListEmployee>
    {
        public RenameTeamListEmployeeJobValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
            RuleFor(x => x.JobTitle).NotEmpty().Length(1, 50).WithMessage("'Job Title' must be a string with a maximum length of 50.");
        }
    }
}
