using FluentValidation;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationQuarterly.Validations.Abstract
{
    public interface IDashboardRegistrationStatisticsQuarterlyValidatorResolver
    {
        IValidator<DashboardRegistrationStatisticsQuarterly> CreateValidator();
    }
}
