using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.View.Entities;

namespace ThreeBytes.ProjectHollywood.Team.View.Validations.Concrete.Validators
{
    public class UpdateTeamViewEmployeeProfileImageValidator : AbstractValidator<TeamViewEmployee>
    {
        public UpdateTeamViewEmployeeProfileImageValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
            RuleFor(x => x.ProfileImageLocation).NotEmpty();
            RuleFor(x => x.ProfileThumbnailImageLocation).NotEmpty();
        }
    }
}