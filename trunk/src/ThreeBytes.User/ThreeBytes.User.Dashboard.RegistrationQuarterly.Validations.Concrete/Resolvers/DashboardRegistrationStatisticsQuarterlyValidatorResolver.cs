using System;
using FluentValidation;
using ThreeBytes.User.Dashboard.RegistrationQuarterly.Validations.Abstract;
using ThreeBytes.User.Dashboard.RegistrationQuarterly.Validations.Concrete.Validators;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Validations.Concrete.Resolvers
{
    public class DashboardRegistrationStatisticsQuarterlyValidatorResolver : IDashboardRegistrationStatisticsQuarterlyValidatorResolver
    {
        private readonly Func<CreateDashboardRegistrationStatisticsQuarterlyValidator> createDashboardRegistrationStatisticsQuarterlyValidator;

        public DashboardRegistrationStatisticsQuarterlyValidatorResolver(Func<CreateDashboardRegistrationStatisticsQuarterlyValidator> createDashboardRegistrationStatisticsQuarterlyValidator)
        {
            this.createDashboardRegistrationStatisticsQuarterlyValidator = createDashboardRegistrationStatisticsQuarterlyValidator;
        }

        public IValidator<DashboardRegistrationStatisticsQuarterly> CreateValidator()
        {
            return createDashboardRegistrationStatisticsQuarterlyValidator();
        }
    }
}
