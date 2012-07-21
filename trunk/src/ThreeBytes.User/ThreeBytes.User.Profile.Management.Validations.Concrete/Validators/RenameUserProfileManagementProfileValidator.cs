using FluentValidation;
using ThreeBytes.User.Profile.Management.Entities;

namespace ThreeBytes.User.Profile.Management.Validations.Concrete.Validators
{
    public class RenameUserProfileManagementProfileValidator : AbstractValidator<UserProfileManagementProfile>
    {
        public RenameUserProfileManagementProfileValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Cannot find item");
            RuleFor(x => x.Forename).Must((profile, forename) => EitherForenameOrSurnameHasValue(profile)).OverridePropertyName("General").WithMessage("Forename or Surname must have a value");
        }

        private bool EitherForenameOrSurnameHasValue(UserProfileManagementProfile profile)
        {
            return !string.IsNullOrEmpty(profile.Forename) || !string.IsNullOrEmpty(profile.Surname);
        }
    }
}