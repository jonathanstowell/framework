using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Team.Management.Validations.Concrete.Validators
{
    public class DeleteTeamManagementEmployeeValidator : AbstractValidator<TeamManagementEmployee>
    {
        public DeleteTeamManagementEmployeeValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
        }
    }
}