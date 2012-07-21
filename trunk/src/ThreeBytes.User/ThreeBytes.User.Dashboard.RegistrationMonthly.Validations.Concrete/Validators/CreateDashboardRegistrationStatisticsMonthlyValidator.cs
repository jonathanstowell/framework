using System;
using FluentValidation;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationMonthly.Validations.Concrete.Validators
{
    public class CreateDashboardRegistrationStatisticsMonthlyValidator : AbstractValidator<DashboardRegistrationStatisticsMonthly>
    {
        public CreateDashboardRegistrationStatisticsMonthlyValidator(IProvideUserConfiguration provideUserConfiguration)
        {
            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Username).NotEmpty().Length(provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength);
            RuleFor(x => x.ApplicationName).NotEmpty().Length(1, 20);
            RuleFor(x => x.Month).NotEmpty().InclusiveBetween(1, 12);
            RuleFor(x => x.Year).NotEmpty().InclusiveBetween(2012, 9999);
        }
    }
}
