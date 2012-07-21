using FluentValidation;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Validations.Concrete.Validators
{
    public class UpdateThespianViewThespianProfileImageValidator : AbstractValidator<ThespianViewThespian>
    {
        public UpdateThespianViewThespianProfileImageValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Thespian does not exist");
            RuleFor(x => x.ProfileImageLocation).NotEmpty();
            RuleFor(x => x.ProfileThumbnailImageLocation).NotEmpty();
        }
    }
}