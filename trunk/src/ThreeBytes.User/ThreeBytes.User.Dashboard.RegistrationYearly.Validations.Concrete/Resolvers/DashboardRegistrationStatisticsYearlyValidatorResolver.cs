using System;
using FluentValidation;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Entities;
using ThreeBytes.User.Dashboard.RegistrationYearly.Validations.Abstract;
using ThreeBytes.User.Dashboard.RegistrationYearly.Validations.Concrete.Validators;

namespace ThreeBytes.User.Dashboard.RegistrationYearly.Validations.Concrete.Resolvers
{
    public class DashboardRegistrationStatisticsYearlyValidatorResolver : IDashboardRegistrationStatisticsYearlyValidatorResolver
    {
        private readonly Func<CreateDashboardRegistrationStatisticsYearlyValidator> createDashboardRegistrationStatisticsYearlyValidator;

        public DashboardRegistrationStatisticsYearlyValidatorResolver(Func<CreateDashboardRegistrationStatisticsYearlyValidator> createDashboardRegistrationStatisticsYearlyValidator)
        {
            this.createDashboardRegistrationStatisticsYearlyValidator = createDashboardRegistrationStatisticsYearlyValidator;
        }

        public IValidator<DashboardRegistrationStatisticsYearly> CreateValidator()
        {
            return createDashboardRegistrationStatisticsYearlyValidator();
        }
    }
}
