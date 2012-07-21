using FluentValidation;
using ThreeBytes.Logging.Exceptions.Management.Entities;

namespace ThreeBytes.Logging.Exceptions.Management.Validations.Concrete.Validators
{
    public class ExceptionManagementValidator : AbstractValidator<ExceptionManagement>
    {
        public ExceptionManagementValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Message).NotNull();
            RuleFor(x => x.Source).NotNull();
        }
    }
}
