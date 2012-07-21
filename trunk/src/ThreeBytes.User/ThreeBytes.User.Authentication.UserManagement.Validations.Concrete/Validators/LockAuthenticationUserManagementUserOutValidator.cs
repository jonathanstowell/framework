using FluentValidation;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Validators
{
    public class LockAuthenticationUserManagementUserOutValidator : AbstractValidator<AuthenticationUserManagementUser>
    {
        public LockAuthenticationUserManagementUserOutValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsLockedOut).Equals(true);
        }
    }
}
