using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.List.Entities;

namespace ThreeBytes.ProjectHollywood.Team.List.Validations.Concrete.Validators
{
    public class UpdateTeamListEmployeeProfileImageValidator : AbstractValidator<TeamListEmployee>
    {
        public UpdateTeamListEmployeeProfileImageValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
            RuleFor(x => x.ProfileImageLocation).NotEmpty();
            RuleFor(x => x.ProfileThumbnailImageLocation).NotEmpty();
        }
    }
}