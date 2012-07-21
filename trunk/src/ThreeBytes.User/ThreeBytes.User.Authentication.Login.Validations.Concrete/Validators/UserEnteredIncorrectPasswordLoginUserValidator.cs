using FluentValidation;
using ThreeBytes.User.Authentication.Login.Configuration.Abstract;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Validators
{
    public class UserEnteredIncorrectPasswordLoginUserValidator : AbstractValidator<LoginUser>
    {
        public UserEnteredIncorrectPasswordLoginUserValidator(IProvideLoginConfiguration loginConfiguration)
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsLockedOut).Equals(false);
            RuleFor(x => x.FailedPasswordAttemptCount).NotEqual(loginConfiguration.LockUserOutAfterNAttempts);
        }
    }
}
