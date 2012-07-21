using FluentValidation;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Validators
{
    public class UnlockAuthenticationUserManagementUserValidator : AbstractValidator<AuthenticationUserManagementUser>
    {
        public UnlockAuthenticationUserManagementUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsLockedOut).Equals(false);
        }
    }
}
