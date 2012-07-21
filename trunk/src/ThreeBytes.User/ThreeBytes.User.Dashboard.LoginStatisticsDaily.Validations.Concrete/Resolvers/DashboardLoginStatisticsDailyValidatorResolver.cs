using System;
using FluentValidation;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Entities;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Validations.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Validations.Concrete.Validators;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Validations.Concrete.Resolvers
{
    public class DashboardLoginStatisticsDailyValidatorResolver : IDashboardLoginStatisticsDailyValidatorResolver
    {
        private readonly Func<CreateDashboardLoginStatisticsDailyValidator> createAuthenticationUserViewRoleValidator;

        public DashboardLoginStatisticsDailyValidatorResolver(Func<CreateDashboardLoginStatisticsDailyValidator> createAuthenticationUserViewRoleValidator)
        {
            this.createAuthenticationUserViewRoleValidator = createAuthenticationUserViewRoleValidator;
        }

        public IValidator<DashboardLoginStatisticsDaily> CreateValidator()
        {
            return createAuthenticationUserViewRoleValidator();
        }
    }
}
