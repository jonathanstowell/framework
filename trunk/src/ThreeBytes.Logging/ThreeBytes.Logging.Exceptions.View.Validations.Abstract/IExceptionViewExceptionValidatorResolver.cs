using FluentValidation;
using ThreeBytes.Logging.Exceptions.View.Entities;

namespace ThreeBytes.Logging.Exceptions.View.Validations.Abstract
{
    public interface IExceptionViewExceptionValidatorResolver
    {
        IValidator<ExceptionView> CreateValidator();
    }
}
