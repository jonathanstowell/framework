using System;
using FluentValidation;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Entities;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Validations.Concrete.Validators
{
    public class CreateDashboardLoginStatisticsMonthlyValidator : AbstractValidator<DashboardLoginStatisticsMonthly>
    {
        public CreateDashboardLoginStatisticsMonthlyValidator(IProvideUserConfiguration provideUserConfiguration)
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
