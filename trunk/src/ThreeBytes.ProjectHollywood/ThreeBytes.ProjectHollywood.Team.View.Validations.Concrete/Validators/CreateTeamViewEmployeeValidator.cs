using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.View.Entities;

namespace ThreeBytes.ProjectHollywood.Team.View.Validations.Concrete.Validators
{
    public class CreateTeamViewEmployeeValidator : AbstractValidator<TeamViewEmployee>
    {
        public CreateTeamViewEmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 35).WithMessage("'First Name' must be a string with a maximum length of 35.");
            RuleFor(x => x.LastName).NotEmpty().Length(1, 35).WithMessage("'Last Name' must be a string with a maximum length of 35.");
            RuleFor(x => x.JobTitle).NotEmpty().Length(1, 50).WithMessage("'Job Title' must be a string with a maximum length of 50.");
            RuleFor(x => x.Summary).NotEmpty();
        }
    }
}
