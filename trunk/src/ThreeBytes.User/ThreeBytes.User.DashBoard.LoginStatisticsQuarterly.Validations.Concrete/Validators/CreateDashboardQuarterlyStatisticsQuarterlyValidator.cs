using System;
using FluentValidation;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Entities;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Validations.Concrete.Validators
{
    public class CreateDashboardQuarterlyStatisticsQuarterlyValidator : AbstractValidator<DashboardLoginStatisticsQuarterly>
    {
        public CreateDashboardQuarterlyStatisticsQuarterlyValidator(IProvideUserConfiguration provideUserConfiguration)
        {
            if (provideUserConfiguration == null)
                throw new ArgumentNullException("provideUserConfiguration");

            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Username).NotEmpty().Length(provideUserConfiguration.MinimumUsernameLength, provideUserConfiguration.MaximumUsernameLength);
            RuleFor(x => x.ApplicationName).NotEmpty().Length(1, 20);
            RuleFor(x => x.Quarter).NotEmpty().InclusiveBetween(1, 4);
            RuleFor(x => x.Year).NotEmpty().InclusiveBetween(2012, 9999);
        }
    }
}
