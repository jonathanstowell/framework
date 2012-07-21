using FluentValidation;
using ThreeBytes.User.Profile.Management.Entities;
using ThreeBytes.User.Profile.Management.Service.Abstract;

namespace ThreeBytes.User.Profile.Management.Validations.Concrete.Validators
{
    public class UpdateEmailUserProfileManagementProfileValidator : AbstractValidator<UserProfileManagementProfile>
    {
        private readonly IProfileManagementProfileService service;

        public UpdateEmailUserProfileManagementProfileValidator(IProfileManagementProfileService service)
        {
            this.service = service;

            RuleFor(x => x).NotNull().WithName("General").WithMessage("Cannot find item");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must((user, email) => UniqueEmail(user)).WithMessage("Must be a unique email address");
        }

        private bool UniqueEmail(UserProfileManagementProfile user)
        {
            return service.UniqueEmail(user.Email, user.ApplicationName);
        }
    }
}