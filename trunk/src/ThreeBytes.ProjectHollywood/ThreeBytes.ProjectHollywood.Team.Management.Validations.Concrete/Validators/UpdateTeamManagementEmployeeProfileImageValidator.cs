using FluentValidation;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Team.Management.Validations.Concrete.Validators
{
    public class UpdateTeamManagementEmployeeProfileImageValidator : AbstractValidator<TeamManagementEmployee>
    {
        public UpdateTeamManagementEmployeeProfileImageValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Employee does not exist");
            RuleFor(x => x.ProfileImageLocation).NotEmpty();
            RuleFor(x => x.ProfileThumbnailImageLocation).NotEmpty();
        }
    }
}