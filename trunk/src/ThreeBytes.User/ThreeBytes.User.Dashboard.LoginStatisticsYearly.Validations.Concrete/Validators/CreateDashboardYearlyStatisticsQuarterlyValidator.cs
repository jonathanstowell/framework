using System;
using FluentValidation;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Entities;

namespace ThreeBytes.User.Dashboard.LoginStatisticsYearly.Validations.Concrete.Validators
{
    public class CreateDashboardYearlyStatisticsQuarterlyValidator : AbstractValidator<DashboardLoginStatisticsYearly>
    {
        public CreateDashboardYearlyStatisticsQuarterlyValidator(IProvideUserConfiguration provideUserConfiguration)
        {
            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Username).NotEmpty().Length(provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength);
            RuleFor(x => x.ApplicationName).NotEmpty().Length(1, 20);
            RuleFor(x => x.Year).NotEmpty().InclusiveBetween(2012, 9999);
        }
    }
}
