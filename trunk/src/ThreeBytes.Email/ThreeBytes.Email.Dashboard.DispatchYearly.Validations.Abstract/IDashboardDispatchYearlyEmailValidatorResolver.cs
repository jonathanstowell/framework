using FluentValidation;
using ThreeBytes.Email.Dashboard.DispatchYearly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Validations.Abstract
{
    public interface IDashboardDispatchYearlyEmailValidatorResolver
    {
        IValidator<DashboardDispatchYearlyEmail> CreateValidator();
    }
}
