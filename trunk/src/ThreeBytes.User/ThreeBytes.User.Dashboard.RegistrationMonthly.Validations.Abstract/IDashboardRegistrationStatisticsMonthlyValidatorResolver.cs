using FluentValidation;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationMonthly.Validations.Abstract
{
    public interface IDashboardRegistrationStatisticsMonthlyValidatorResolver
    {
        IValidator<DashboardRegistrationStatisticsMonthly> CreateValidator();
    }
}
