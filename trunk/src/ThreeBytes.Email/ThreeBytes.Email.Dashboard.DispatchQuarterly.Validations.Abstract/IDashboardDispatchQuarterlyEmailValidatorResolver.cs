using FluentValidation;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Validations.Abstract
{
    public interface IDashboardDispatchQuarterlyEmailValidatorResolver
    {
        IValidator<DashboardDispatchQuarterlyEmail> CreateValidator();
    }
}
