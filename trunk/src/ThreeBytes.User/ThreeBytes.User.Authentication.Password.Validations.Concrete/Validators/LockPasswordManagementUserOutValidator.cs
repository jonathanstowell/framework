using FluentValidation;
using ThreeBytes.User.Authentication.Password.Entities;

namespace ThreeBytes.User.Authentication.Password.Validations.Concrete.Validators
{
    public class LockPasswordManagementUserOutValidator : AbstractValidator<PasswordManagementUser>
    {
        public LockPasswordManagementUserOutValidator()
        {
            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");
            RuleFor(x => x.IsLockedOut).Equals(true);
            RuleFor(x => x.UnlockCode).NotEmpty();
        }
    }
}
