using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Validators
{
    public class UnlockUserLoginUserValidator : AbstractValidator<LoginUser>
    {
        public UnlockUserLoginUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsLockedOut).Equals(false);
        }
    }
}
