using FluentValidation;
using ThreeBytes.User.Authentication.UserView.Entities;

namespace ThreeBytes.User.Authentication.UserView.Validations.Concrete.Validators
{
    public class UnlockAuthenticationUserViewUserValidator : AbstractValidator<AuthenticationUserViewUser>
    {
        public UnlockAuthenticationUserViewUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsLockedOut).Equals(false);
        }
    }
}
