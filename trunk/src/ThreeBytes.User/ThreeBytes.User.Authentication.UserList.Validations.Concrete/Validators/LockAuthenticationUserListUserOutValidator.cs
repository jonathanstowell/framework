using FluentValidation;
using ThreeBytes.User.Authentication.UserList.Entities;

namespace ThreeBytes.User.Authentication.UserList.Validations.Concrete.Validators
{
    public class LockAuthenticationUserListUserOutValidator : AbstractValidator<AuthenticationUserListUser>
    {
        public LockAuthenticationUserListUserOutValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsLockedOut).Equals(true);
        }
    }
}
