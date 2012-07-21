using FluentValidation;
using ThreeBytes.Email.Dashboard.DispatchYearly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Validations.Concrete.Validators
{
    public class CreateDashboardDispatchYearlyEmailValidator : AbstractValidator<DashboardDispatchYearlyEmail>
    {
        public CreateDashboardDispatchYearlyEmailValidator()
        {
            RuleFor(x => x.ApplicationName).NotNull().NotEmpty().Length(1, 20);
            RuleFor(x => x.To).NotNull().NotEmpty().EmailAddress().Length(1, 128);
            RuleFor(x => x.Subject).NotNull().NotEmpty().Length(1, 255);
            RuleFor(x => x.Year).NotNull().NotEmpty().InclusiveBetween(2012, 9999);
        }
    }
}
