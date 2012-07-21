using FluentValidation;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Validations.Concrete.Validators
{
    public class CreateDashboardDispatchQuarterlyEmailValidator : AbstractValidator<DashboardDispatchQuarterlyEmail>
    {
        public CreateDashboardDispatchQuarterlyEmailValidator()
        {
            RuleFor(x => x.ApplicationName).NotNull().NotEmpty().Length(1, 20);
            RuleFor(x => x.To).NotNull().NotEmpty().EmailAddress().Length(1, 128);
            RuleFor(x => x.Subject).NotNull().NotEmpty().Length(1, 255);
            RuleFor(x => x.Quarter).NotNull().NotEmpty().InclusiveBetween(1, 4);
            RuleFor(x => x.Year).NotNull().NotEmpty().InclusiveBetween(2012, 9999);
        }
    }
}
