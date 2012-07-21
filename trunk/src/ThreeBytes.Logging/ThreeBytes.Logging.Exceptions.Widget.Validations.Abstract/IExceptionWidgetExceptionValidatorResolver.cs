using FluentValidation;
using ThreeBytes.Logging.Exceptions.Widget.Entities;

namespace ThreeBytes.Logging.Exceptions.Widget.Validations.Abstract
{
    public interface IExceptionWidgetExceptionValidatorResolver
    {
        IValidator<ExceptionWidget> CreateValidator();
    }
}
