using FluentValidation;
using ThreeBytes.Logging.Exceptions.Management.Entities;

namespace ThreeBytes.Logging.Exceptions.Management.Validations.Abstract
{
    public interface IExceptionManagementExceptionValidatorResolver
    {
        IValidator<ExceptionManagement> CreateValidator();
    }
}
