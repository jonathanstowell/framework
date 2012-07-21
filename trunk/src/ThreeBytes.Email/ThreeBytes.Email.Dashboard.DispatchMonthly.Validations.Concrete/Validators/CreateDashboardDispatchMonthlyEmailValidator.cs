using FluentValidation;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Validations.Concrete.Validators
{
    public class CreateDashboardDispatchMonthlyEmailValidator : AbstractValidator<DashboardDispatchMonthlyEmail>
    {
        public CreateDashboardDispatchMonthlyEmailValidator()
        {
            RuleFor(x => x.ApplicationName).NotNull().NotEmpty().Length(1, 20);
            RuleFor(x => x.To).NotNull().NotEmpty().EmailAddress().Length(1, 128);
            RuleFor(x => x.Subject).NotNull().NotEmpty().Length(1, 255);
            RuleFor(x => x.Month).NotNull().NotEmpty().InclusiveBetween(1, 12);
            RuleFor(x => x.Year).NotNull().NotEmpty().InclusiveBetween(2012, 9999);
        }
    }
}
