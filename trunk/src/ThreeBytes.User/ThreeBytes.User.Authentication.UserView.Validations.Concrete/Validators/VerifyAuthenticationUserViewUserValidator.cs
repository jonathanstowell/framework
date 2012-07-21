using FluentValidation;
using ThreeBytes.User.Authentication.UserView.Entities;

namespace ThreeBytes.User.Authentication.UserView.Validations.Concrete.Validators
{
    public class VerifyAuthenticationUserViewUserValidator : AbstractValidator<AuthenticationUserViewUser>
    {
        public VerifyAuthenticationUserViewUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsVerified).Equals(true);
        }
    }
}
