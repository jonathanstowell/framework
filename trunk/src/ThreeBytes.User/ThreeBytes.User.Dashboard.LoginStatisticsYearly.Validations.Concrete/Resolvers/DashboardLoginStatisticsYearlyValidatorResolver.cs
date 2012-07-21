using System;
using FluentValidation;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Entities;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Validations.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Validations.Concrete.Validators;

namespace ThreeBytes.User.Dashboard.LoginStatisticsYearly.Validations.Concrete.Resolvers
{
    public class DashboardLoginStatisticsYearlyValidatorResolver : IDashboardLoginStatisticsYearlyValidatorResolver
    {
        private readonly Func<CreateDashboardYearlyStatisticsQuarterlyValidator> createAuthenticationUserViewRoleValidator;

        public DashboardLoginStatisticsYearlyValidatorResolver(Func<CreateDashboardYearlyStatisticsQuarterlyValidator> createAuthenticationUserViewRoleValidator)
        {
            this.createAuthenticationUserViewRoleValidator = createAuthenticationUserViewRoleValidator;
        }

        public IValidator<DashboardLoginStatisticsYearly> CreateValidator()
        {
            return createAuthenticationUserViewRoleValidator();
        }
    }
}
