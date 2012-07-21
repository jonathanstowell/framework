using System;
using FluentValidation;
using ThreeBytes.Logging.Exceptions.Management.Entities;
using ThreeBytes.Logging.Exceptions.Management.Validations.Abstract;
using ThreeBytes.Logging.Exceptions.Management.Validations.Concrete.Validators;

namespace ThreeBytes.Logging.Exceptions.Management.Validations.Concrete.Resolvers
{
    public class ExceptionManagementExceptionValidatorResolver : IExceptionManagementExceptionValidatorResolver
    {
        private readonly Func<ExceptionManagementValidator> createExceptionManagementValidator;

        public ExceptionManagementExceptionValidatorResolver(Func<ExceptionManagementValidator> createExceptionManagementValidator)
        {
            this.createExceptionManagementValidator = createExceptionManagementValidator;
        }

        public IValidator<ExceptionManagement> CreateValidator()
        {
            return createExceptionManagementValidator();
        }
    }
}
