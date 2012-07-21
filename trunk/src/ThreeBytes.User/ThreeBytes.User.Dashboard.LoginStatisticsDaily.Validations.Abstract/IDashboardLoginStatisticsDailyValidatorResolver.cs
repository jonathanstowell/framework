using FluentValidation;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Entities;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Validations.Abstract
{
    public interface IDashboardLoginStatisticsDailyValidatorResolver
    {
        IValidator<DashboardLoginStatisticsDaily> CreateValidator();
    }
}
