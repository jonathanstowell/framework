using FluentValidation;
using ThreeBytes.Email.Dashboard.DispatchDaily.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchDaily.Validations.Abstract
{
    public interface IDashboardDispatchDailyEmailValidatorResolver
    {
        IValidator<DashboardDispatchDailyEmail> CreateValidator();
    }
}
