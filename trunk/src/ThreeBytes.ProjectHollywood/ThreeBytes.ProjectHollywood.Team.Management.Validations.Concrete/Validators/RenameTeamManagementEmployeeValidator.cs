using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Team.Management.Validations.Concrete.Validators
{
    public class RenameTeamManagementEmployeeValidator : AbstractValidator<TeamManagementEmployee>
    {
        public RenameTeamManagementEmployeeValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 35).WithMessage("'First Name' must be a string with a maximum length of 35.");
            RuleFor(x => x.LastName).NotEmpty().Length(1, 35).WithMessage("'Last Name' must be a string with a maximum length of 35.");
        }
    }
}