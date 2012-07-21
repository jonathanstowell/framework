using FluentValidation;
using ThreeBytes.User.Profile.View.Entities;
using ThreeBytes.User.Profile.View.Service.Abstract;

namespace ThreeBytes.User.Profile.View.Validations.Concrete.Validators
{
    public class UpdateEmailUserProfileViewProfileValidator : AbstractValidator<UserProfileViewProfile>
    {
        private readonly IProfileViewProfileService service;

        public UpdateEmailUserProfileViewProfileValidator(IProfileViewProfileService service)
        {
            this.service = service;

            RuleFor(x => x).NotNull().WithName("General").WithMessage("Cannot find item");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must((user, email) => UniqueEmail(user)).WithMessage("Must be a unique email address");
        }

        private bool UniqueEmail(UserProfileViewProfile user)
        {
            return service.UniqueEmail(user.ItemId, user.Email, user.ApplicationName);
        }
    }
}