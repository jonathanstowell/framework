using FluentValidation;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Validations.Concrete.Validators
{
    public class VerifyUserLoginUserValidator : AbstractValidator<LoginUser>
    {
        public VerifyUserLoginUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsVerified).Equals(true);
        }
    }
}
