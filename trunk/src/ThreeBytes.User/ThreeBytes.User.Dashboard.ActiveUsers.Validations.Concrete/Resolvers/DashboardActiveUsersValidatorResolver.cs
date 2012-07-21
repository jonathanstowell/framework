using System;
using FluentValidation;
using ThreeBytes.User.Dashboard.ActiveUsers.Entities;
using ThreeBytes.User.Dashboard.ActiveUsers.Validations.Abstract;
using ThreeBytes.User.Dashboard.ActiveUsers.Validations.Concrete.Validators;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Validations.Concrete.Resolvers
{
    public class DashboardActiveUsersValidatorResolver : IDashboardActiveUsersValidatorResolver
    {
        private readonly Func<CreateDashboardActiveUsersValidator> createAuthenticationUserViewRoleValidator;
        private readonly Func<UpdateDashboardActiveUsersValidator> updateDashboardActiveUsersValidator;

        public DashboardActiveUsersValidatorResolver(Func<CreateDashboardActiveUsersValidator> createAuthenticationUserViewRoleValidator, Func<UpdateDashboardActiveUsersValidator> updateDashboardActiveUsersValidator)
        {
            this.createAuthenticationUserViewRoleValidator = createAuthenticationUserViewRoleValidator;
            this.updateDashboardActiveUsersValidator = updateDashboardActiveUsersValidator;
        }

        public IValidator<DashboardActiveUsers> CreateValidator()
        {
            return createAuthenticationUserViewRoleValidator();
        }

        public IValidator<DashboardActiveUsers> UpdateValidator()
        {
            return updateDashboardActiveUsersValidator();
        }
    }
}
