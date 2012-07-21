using FluentValidation;
using ThreeBytes.User.Authentication.Password.Entities;

namespace ThreeBytes.User.Authentication.Password.Validations.Concrete.Validators
{
    public class UnlockPasswordManagementUserValidator : AbstractValidator<PasswordManagementUser>
    {
        public UnlockPasswordManagementUserValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsLockedOut).Equals(false);
            RuleFor(x => x.UnlockCode).Equals(null);
        }
    }
}
