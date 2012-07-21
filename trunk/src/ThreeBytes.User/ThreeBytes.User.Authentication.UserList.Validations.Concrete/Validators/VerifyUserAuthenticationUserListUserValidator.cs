using FluentValidation;
using ThreeBytes.User.Authentication.UserList.Entities;

namespace ThreeBytes.User.Authentication.UserList.Validations.Concrete.Validators
{
    public class VerifyUserAuthenticationUserListUserValidator : AbstractValidator<AuthenticationUserListUser>
    {
        public VerifyUserAuthenticationUserListUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsVerified).Equals(true);
        }
    }
}
