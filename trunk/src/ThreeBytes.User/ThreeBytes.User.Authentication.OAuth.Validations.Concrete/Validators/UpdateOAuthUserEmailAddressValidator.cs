using FluentValidation;
using ThreeBytes.User.Authentication.OAuth.Entities;

namespace ThreeBytes.User.Authentication.OAuth.Validations.Concrete.Validators
{
    public class UpdateOAuthUserEmailAddressValidator : AbstractValidator<OAuthUser>
    {
        public UpdateOAuthUserEmailAddressValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
        }
    }
}