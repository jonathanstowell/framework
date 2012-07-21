using System;
using FluentValidation;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationDaily.Validations.Concrete.Validators
{
    public class CreateDashboardRegistrationStatisticsDailyValidator : AbstractValidator<DashboardRegistrationStatisticsDaily>
    {
        public CreateDashboardRegistrationStatisticsDailyValidator(IProvideUserConfiguration provideUserConfiguration)
        {
            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Username).NotEmpty().Length(provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength);
            RuleFor(x => x.ApplicationName).NotEmpty().Length(1, 20);
            RuleFor(x => x.RegistrationDateTime).NotEmpty().LessThan(DateTime.Now);
        }
    }
}
