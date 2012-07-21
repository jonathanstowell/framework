using FluentValidation;
using ThreeBytes.Logging.Exceptions.List.Entities;

namespace ThreeBytes.Logging.Exceptions.List.Validations.Concrete.Validators
{
    public class ExceptionListValidator : AbstractValidator<ExceptionList>
    {
        public ExceptionListValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Message).NotNull();
            RuleFor(x => x.Source).NotNull();
        }
    }
}
