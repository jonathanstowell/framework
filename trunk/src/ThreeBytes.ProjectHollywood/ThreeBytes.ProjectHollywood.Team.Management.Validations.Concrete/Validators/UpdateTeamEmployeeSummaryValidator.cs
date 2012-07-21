using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Team.Management.Validations.Concrete.Validators
{
    public class UpdateTeamEmployeeSummaryValidator : AbstractValidator<TeamManagementEmployee>
    {
        public UpdateTeamEmployeeSummaryValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
            RuleFor(x => x.Summary).NotEmpty();
        }
    }
}
