using FluentValidation;
using ThreeBytes.Logging.Exceptions.List.Entities;

namespace ThreeBytes.Logging.Exceptions.List.Validations.Abstract
{
    public interface IExceptionListExceptionValidatorResolver
    {
        IValidator<ExceptionList> CreateValidator();
    }
}
