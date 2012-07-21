using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Validations.Concrete.Validators
{
    public class UpdateThespianListThespianProfileImageValidator : AbstractValidator<ThespianListThespian>
    {
        public UpdateThespianListThespianProfileImageValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Thespian does not exist");
            RuleFor(x => x.ProfileImageLocation).NotEmpty();
            RuleFor(x => x.ProfileThumbnailImageLocation).NotEmpty();
        }
    }
}