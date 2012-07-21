using System;
using FluentValidation;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.ActiveUsers.Entities;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Validations.Concrete.Validators
{
    public class UpdateDashboardActiveUsersValidator : AbstractValidator<DashboardActiveUsers>
    {
        public UpdateDashboardActiveUsersValidator(IProvideUserConfiguration provideUserConfiguration)
        {
            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            RuleFor(x => x.Username).NotEmpty().Length(provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength);
            RuleFor(x => x.ApplicationName).NotEmpty().Length(1, 20);
            RuleFor(x => x.Logins).NotEmpty().GreaterThan(0);
        }
    }
}
