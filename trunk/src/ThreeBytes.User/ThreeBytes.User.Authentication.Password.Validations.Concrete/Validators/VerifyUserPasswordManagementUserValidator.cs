using FluentValidation;
using ThreeBytes.User.Authentication.Password.Entities;

namespace ThreeBytes.User.Authentication.Password.Validations.Concrete.Validators
{
    public class VerifyUserPasswordManagementUserValidator : AbstractValidator<PasswordManagementUser>
    {
        public VerifyUserPasswordManagementUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsVerified).Equals(true);
        }
    }
}
