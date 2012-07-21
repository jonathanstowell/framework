using FluentValidation;
using ThreeBytes.Logging.Exceptions.View.Entities;

namespace ThreeBytes.Logging.Exceptions.View.Validations.Concrete.Validators
{
    public class ExceptionViewValidator : AbstractValidator<ExceptionView>
    {
        public ExceptionViewValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Message).NotNull();
            RuleFor(x => x.Source).NotNull();
            RuleFor(x => x.StackTrace).NotNull();
        }
    }
}
