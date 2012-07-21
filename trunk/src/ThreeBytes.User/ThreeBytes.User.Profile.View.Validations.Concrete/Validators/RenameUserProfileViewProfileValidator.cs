using FluentValidation;
using ThreeBytes.User.Profile.View.Entities;

namespace ThreeBytes.User.Profile.View.Validations.Concrete.Validators
{
    public class RenameUserProfileViewProfileValidator : AbstractValidator<UserProfileViewProfile>
    {
        public RenameUserProfileViewProfileValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("Cannot find item");
            RuleFor(x => x.Forename).Must((profile, forename) => EitherForenameOrSurnameHasValue(profile)).OverridePropertyName("General").WithMessage("Forename or Surname must have a value");
        }

        private bool EitherForenameOrSurnameHasValue(UserProfileViewProfile profile)
        {
            return !string.IsNullOrEmpty(profile.Forename) || !string.IsNullOrEmpty(profile.Surname);
        }
    }
}