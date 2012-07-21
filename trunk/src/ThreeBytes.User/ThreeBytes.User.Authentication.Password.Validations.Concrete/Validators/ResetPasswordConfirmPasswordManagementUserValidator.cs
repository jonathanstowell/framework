using FluentValidation;
using ThreeBytes.User.Authentication.Password.Entities;
using ThreeBytes.User.Authentication.Password.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Password.Validations.Concrete.Validators
{
    public class ResetPasswordConfirmPasswordManagementUserValidator : AbstractValidator<PasswordManagementUser>
    {
        private readonly IPasswordManagementUserService service;

        public ResetPasswordConfirmPasswordManagementUserValidator(IPasswordManagementUserService service, IProvideUserConfiguration provideUserConfiguration)
        {
            this.service = service;

            RuleFor(x => x).NotNull().WithName("General").WithMessage("User does not exist");

            RuleFor(x => x.Password)
                .NotEmpty()
                .Length(provideUserConfiguration.MinimumPasswordLength, provideUserConfiguration.MaximumPasswordLength);

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Length(provideUserConfiguration.MinimumPasswordLength, provideUserConfiguration.MaximumPasswordLength)
                .Must((user, password) => ConfirmPasswordMatchesPassword(user)).WithMessage("Passwords must match.");

            RuleFor(x => x.ResetPasswordCode)
                    .NotEmpty()
                    .Must((user, code) => PasswordCodeMatches(user)).WithMessage("Password Code must match the code sent to you.");
        }

        private bool ConfirmPasswordMatchesPassword(PasswordManagementUser user)
        {
            if (user == null)
                return true;

            return user.Password == user.ConfirmPassword;
        }

        private bool PasswordCodeMatches(PasswordManagementUser user)
        {
            if (user == null)
                return true;

            if (user.ResetPasswordCode == null)
                return false;

            return service.ResetPasswordCodeMatches(user.Id, user.ResetPasswordCode.Value);
        }
    }
}
