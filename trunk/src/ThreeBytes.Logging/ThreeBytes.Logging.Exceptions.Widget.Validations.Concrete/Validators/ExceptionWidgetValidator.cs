using FluentValidation;
using ThreeBytes.Logging.Exceptions.Widget.Entities;

namespace ThreeBytes.Logging.Exceptions.Widget.Validations.Concrete.Validators
{
    public class ExceptionWidgetValidator : AbstractValidator<ExceptionWidget>
    {
        public ExceptionWidgetValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Message).NotNull();
            RuleFor(x => x.Source).NotNull();
        }
    }
}
