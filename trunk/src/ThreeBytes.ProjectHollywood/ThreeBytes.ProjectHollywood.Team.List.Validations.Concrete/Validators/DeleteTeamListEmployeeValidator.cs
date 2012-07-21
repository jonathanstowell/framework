using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.List.Entities;

namespace ThreeBytes.ProjectHollywood.Team.List.Validations.Concrete.Validators
{
    public class DeleteTeamListEmployeeValidator : AbstractValidator<TeamListEmployee>
    {
        public DeleteTeamListEmployeeValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
        }
    }
}