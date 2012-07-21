using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Team.Management.Validations.Concrete.Validators
{
    public class CreateTeamManagementEmployeeValidator : AbstractValidator<TeamManagementEmployee>
    {
        public CreateTeamManagementEmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 35).WithMessage("'First Name' must be a string with a maximum length of 35.");
            RuleFor(x => x.LastName).NotEmpty().Length(1, 35).WithMessage("'Last Name' must be a string with a maximum length of 35.");
            RuleFor(x => x.JobTitle).NotEmpty().Length(1, 50).WithMessage("'Job Title' must be a string with a maximum length of 50.");
            RuleFor(x => x.Summary).NotEmpty();
        }
    }
}
