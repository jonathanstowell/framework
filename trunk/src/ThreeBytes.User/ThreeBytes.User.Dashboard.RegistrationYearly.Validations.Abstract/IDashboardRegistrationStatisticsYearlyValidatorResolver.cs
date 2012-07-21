using FluentValidation;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationYearly.Validations.Abstract
{
    public interface IDashboardRegistrationStatisticsYearlyValidatorResolver
    {
        IValidator<DashboardRegistrationStatisticsYearly> CreateValidator();
    }
}
