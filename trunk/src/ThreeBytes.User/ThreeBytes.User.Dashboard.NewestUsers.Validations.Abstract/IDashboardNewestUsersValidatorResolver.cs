using FluentValidation;
using ThreeBytes.User.Dashboard.NewestUsers.Entities;

namespace ThreeBytes.User.Dashboard.NewestUsers.Validations.Abstract
{
    public interface IDashboardNewestUsersValidatorResolver
    {
        IValidator<DashboardNewestUsers> CreateValidator();
    }
}
