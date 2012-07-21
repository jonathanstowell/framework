using FluentValidation;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Entities;

namespace ThreeBytes.User.Dashboard.LoginStatisticsYearly.Validations.Abstract
{
    public interface IDashboardLoginStatisticsYearlyValidatorResolver
    {
        IValidator<DashboardLoginStatisticsYearly> CreateValidator();
    }
}
