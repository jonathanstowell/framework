using System;
using FluentValidation;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Entities;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Validations.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Validations.Concrete.Validators;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Validations.Concrete.Resolvers
{
    public class DashboardLoginStatisticsMonthlyValidatorResolver : IDashboardLoginStatisticsMonthlyValidatorResolver
    {
        private readonly Func<CreateDashboardLoginStatisticsMonthlyValidator> createAuthenticationUserViewRoleValidator;

        public DashboardLoginStatisticsMonthlyValidatorResolver(Func<CreateDashboardLoginStatisticsMonthlyValidator> createAuthenticationUserViewRoleValidator)
        {
            this.createAuthenticationUserViewRoleValidator = createAuthenticationUserViewRoleValidator;
        }

        public IValidator<DashboardLoginStatisticsMonthly> CreateValidator()
        {
            return createAuthenticationUserViewRoleValidator();
        }
    }
}
