using FluentValidation;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Validations.Concrete.Validators
{
    public class VerifyAuthenticationUserManagementUserValidator : AbstractValidator<AuthenticationUserManagementUser>
    {
        public VerifyAuthenticationUserManagementUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsVerified).Equals(true);
        }
    }
}
