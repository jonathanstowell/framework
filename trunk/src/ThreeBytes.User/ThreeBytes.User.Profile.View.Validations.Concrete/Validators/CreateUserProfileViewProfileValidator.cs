using FluentValidation;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Profile.View.Entities;
using ThreeBytes.User.Profile.View.Service.Abstract;

namespace ThreeBytes.User.Profile.View.Validations.Concrete.Validators
{
    public class CreateUserProfileViewProfileValidator : AbstractValidator<UserProfileViewProfile>
    {
        private readonly IProfileViewProfileService service;

        public CreateUserProfileViewProfileValidator(IProfileViewProfileService service, IProvideUserConfiguration provideUserConfiguration)
        {
            this.service = service;

            RuleFor(x => x.Username).NotEmpty().Length(provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must((user, email) => UniqueEmail(user)).WithMessage("Must be a unique email address");
            RuleFor(x => x.ApplicationName).NotEmpty().Length(1, 20);
        }

        private bool UniqueEmail(UserProfileViewProfile user)
        {
            return service.UniqueEmail(user.ItemId, user.Email, user.ApplicationName);
        }
    }
}
