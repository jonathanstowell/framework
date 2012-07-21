using FluentValidation;
using ThreeBytes.User.Authentication.UserList.Entities;

namespace ThreeBytes.User.Authentication.UserList.Validations.Concrete.Validators
{
    public class UnlockAuthenticationUserListUserValidator : AbstractValidator<AuthenticationUserListUser>
    {
        public UnlockAuthenticationUserListUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsLockedOut).Equals(false);
        }
    }
}
