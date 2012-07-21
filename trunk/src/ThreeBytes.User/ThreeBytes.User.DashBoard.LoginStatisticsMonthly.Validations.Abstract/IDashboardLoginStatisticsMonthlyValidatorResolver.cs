using FluentValidation;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Entities;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Validations.Abstract
{
    public interface IDashboardLoginStatisticsMonthlyValidatorResolver
    {
        IValidator<DashboardLoginStatisticsMonthly> CreateValidator();
    }
}
