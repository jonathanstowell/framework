using FluentValidation;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Validations.Abstract
{
    public interface IDashboardDispatchMonthlyEmailValidatorResolver
    {
        IValidator<DashboardDispatchMonthlyEmail> CreateValidator();
    }
}
