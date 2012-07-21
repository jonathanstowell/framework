using System;
using FluentValidation;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Entities;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Validations.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Validations.Concrete.Validators;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Validations.Concrete.Resolvers
{
    public class DashboardLoginStatisticsQuarterlyValidatorResolver : IDashboardLoginStatisticsQuarterlyValidatorResolver
    {
        private readonly Func<CreateDashboardQuarterlyStatisticsQuarterlyValidator> createAuthenticationUserViewRoleValidator;

        public DashboardLoginStatisticsQuarterlyValidatorResolver(Func<CreateDashboardQuarterlyStatisticsQuarterlyValidator> createAuthenticationUserViewRoleValidator)
        {
            this.createAuthenticationUserViewRoleValidator = createAuthenticationUserViewRoleValidator;
        }

        public IValidator<DashboardLoginStatisticsQuarterly> CreateValidator()
        {
            return createAuthenticationUserViewRoleValidator();
        }
    }
}
