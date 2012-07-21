using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Concrete.Validators
{
    public class UpdateThespianManagementThespianProfileImageValidator : AbstractValidator<ThespianManagementThespian>
    {
        public UpdateThespianManagementThespianProfileImageValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Thespian does not exist");
            RuleFor(x => x.ProfileImageLocation).NotEmpty();
            RuleFor(x => x.ProfileThumbnailImageLocation).NotEmpty();
        }
    }
}