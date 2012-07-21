using FluentValidation;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Entities;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Validations.Abstract
{
    public interface IDashboardLoginStatisticsQuarterlyValidatorResolver
    {
        IValidator<DashboardLoginStatisticsQuarterly> CreateValidator();
    }
}
