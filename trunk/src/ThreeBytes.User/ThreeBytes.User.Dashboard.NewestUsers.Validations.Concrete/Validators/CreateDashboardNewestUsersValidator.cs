using System;
using FluentValidation;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.NewestUsers.Entities;

namespace ThreeBytes.User.Dashboard.NewestUsers.Validations.Concrete.Validators
{
    public class CreateDashboardNewestUsersValidator : AbstractValidator<DashboardNewestUsers>
    {
        public CreateDashboardNewestUsersValidator(IProvideUserConfiguration provideUserConfiguration)
        {
            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            RuleFor(x => x.Username).NotEmpty().Length(provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength);
            RuleFor(x => x.ApplicationName).NotEmpty().Length(1, 20);
            RuleFor(x => x.RegistrationDateTime).NotEmpty().LessThan(DateTime.Now);
        }
    }
}
