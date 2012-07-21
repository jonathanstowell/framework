using System;
using FluentValidation;
using ThreeBytes.User.Dashboard.RegistrationMonthly.Validations.Abstract;
using ThreeBytes.User.Dashboard.RegistrationMonthly.Validations.Concrete.Validators;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationMonthly.Validations.Concrete.Resolvers
{
    public class DashboardDashboardRegistrationStatisticsMonthlyValidatorResolver : IDashboardRegistrationStatisticsMonthlyValidatorResolver
    {
        private readonly Func<CreateDashboardRegistrationStatisticsMonthlyValidator> createDashboardRegistrationStatisticsMonthlyValidator;

        public DashboardDashboardRegistrationStatisticsMonthlyValidatorResolver(Func<CreateDashboardRegistrationStatisticsMonthlyValidator> createDashboardRegistrationStatisticsMonthlyValidator)
        {
            this.createDashboardRegistrationStatisticsMonthlyValidator = createDashboardRegistrationStatisticsMonthlyValidator;
        }

        public IValidator<DashboardRegistrationStatisticsMonthly> CreateValidator()
        {
            return createDashboardRegistrationStatisticsMonthlyValidator();
        }
    }
}
