using System;
using FluentValidation;
using ThreeBytes.User.Dashboard.NewestUsers.Entities;
using ThreeBytes.User.Dashboard.NewestUsers.Validations.Abstract;
using ThreeBytes.User.Dashboard.NewestUsers.Validations.Concrete.Validators;

namespace ThreeBytes.User.Dashboard.NewestUsers.Validations.Concrete.Resolvers
{
    public class DashboardNewestUsersValidatorResolver : IDashboardNewestUsersValidatorResolver
    {
        private readonly Func<CreateDashboardNewestUsersValidator> createDashboardNewestUsersValidator;

        public DashboardNewestUsersValidatorResolver(Func<CreateDashboardNewestUsersValidator> createDashboardNewestUsersValidator)
        {
            this.createDashboardNewestUsersValidator = createDashboardNewestUsersValidator;
        }

        public IValidator<DashboardNewestUsers> CreateValidator()
        {
            return createDashboardNewestUsersValidator();
        }
    }
}
