using FluentValidation;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Profile.Management.Entities;
using ThreeBytes.User.Profile.Management.Service.Abstract;

namespace ThreeBytes.User.Profile.Management.Validations.Concrete.Validators
{
    public class CreateUserProfileManagementProfileValidator : AbstractValidator<UserProfileManagementProfile>
    {
        private readonly IProfileManagementProfileService service;

        public CreateUserProfileManagementProfileValidator(IProvideUserConfiguration provideUserConfiguration, IProfileManagementProfileService service)
        {
            this.service = service;

            RuleFor(x => x.Username).NotEmpty().Length(provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must((user, email) => UniqueEmail(user)).WithMessage("Must be a unique email address");
            RuleFor(x => x.ApplicationName).NotEmpty().Length(1, 20).WithMessage("'Application Name' must be a string with a maximum length of 20.");
        }

        private bool UniqueEmail(UserProfileManagementProfile user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }
    }
}
