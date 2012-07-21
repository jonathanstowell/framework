using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Validators
{
    public class AuthenticateUserValidator : AbstractValidator<LoginUser>
    {
        public AuthenticateUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("Username").WithMessage("User does not exist");
            RuleFor(x => x.IsVerified).Equals(true);
            RuleFor(x => x.IsLockedOut).Equals(false);
        }
    }
}
