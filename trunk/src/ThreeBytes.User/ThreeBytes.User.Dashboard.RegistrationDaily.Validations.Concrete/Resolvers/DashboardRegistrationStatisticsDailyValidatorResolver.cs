using System;
using FluentValidation;
using ThreeBytes.User.Dashboard.RegistrationDaily.Validations.Abstract;
using ThreeBytes.User.Dashboard.RegistrationDaily.Validations.Concrete.Validators;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Validations.Concrete.Resolvers
{
    public class DashboardRegistrationStatisticsDailyValidatorResolver : IDashboardRegistrationStatisticsDailyValidatorResolver
    {
        private readonly Func<CreateDashboardRegistrationStatisticsDailyValidator> createDashboardRegistrationStatisticsDailyValidator;

        public DashboardRegistrationStatisticsDailyValidatorResolver(Func<CreateDashboardRegistrationStatisticsDailyValidator> createDashboardRegistrationStatisticsDailyValidator)
        {
            this.createDashboardRegistrationStatisticsDailyValidator = createDashboardRegistrationStatisticsDailyValidator;
        }

        public IValidator<DashboardRegistrationStatisticsDaily> CreateValidator()
        {
            return createDashboardRegistrationStatisticsDailyValidator();
        }
    }
}
