using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Team.Management.Validations.Concrete.Validators
{
    public class RenameTeamManagementEmployeeJobValidator : AbstractValidator<TeamManagementEmployee>
    {
        public RenameTeamManagementEmployeeJobValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
            RuleFor(x => x.JobTitle).NotEmpty().Length(1, 50).WithMessage("'Job Title' must be a string with a maximum length of 50.");
        }
    }
}
