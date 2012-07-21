using FluentValidation;
using ThreeBytes.User.Dashboard.ActiveUsers.Entities;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Validations.Abstract
{
    public interface IDashboardActiveUsersValidatorResolver
    {
        IValidator<DashboardActiveUsers> CreateValidator();
        IValidator<DashboardActiveUsers> UpdateValidator();
    }
}
