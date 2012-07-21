using FluentValidation;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationDaily.Validations.Abstract
{
    public interface IDashboardRegistrationStatisticsDailyValidatorResolver
    {
        IValidator<DashboardRegistrationStatisticsDaily> CreateValidator();
    }
}
