using System;
using FluentValidation;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Entities;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Validations.Concrete.Validators
{
    public class CreateDashboardLoginStatisticsDailyValidator : AbstractValidator<DashboardLoginStatisticsDaily>
    {
        public CreateDashboardLoginStatisticsDailyValidator(IProvideUserConfiguration provideUserConfiguration)
        {
            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Username).NotEmpty().Length(provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength);
            RuleFor(x => x.ApplicationName).NotEmpty().Length(1, 20);
            RuleFor(x => x.LoginDate).NotEmpty().LessThan(DateTime.Now);
        }
    }
}
