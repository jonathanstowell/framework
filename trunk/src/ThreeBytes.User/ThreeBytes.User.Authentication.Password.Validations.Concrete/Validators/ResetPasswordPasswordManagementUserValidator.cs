using FluentValidation;
using ThreeBytes.User.Authentication.Password.Entities;

namespace ThreeBytes.User.Authentication.Password.Validations.Concrete.Validators
{
    public class ResetPasswordPasswordManagementUserValidator : AbstractValidator<PasswordManagementUser>
    {
        public ResetPasswordPasswordManagementUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("UserIdentifier").WithMessage("User does not exist");
        }
    }
}
