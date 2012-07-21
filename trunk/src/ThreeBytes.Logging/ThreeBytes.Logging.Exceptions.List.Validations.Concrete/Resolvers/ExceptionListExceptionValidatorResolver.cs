using System;
using FluentValidation;
using ThreeBytes.Logging.Exceptions.List.Entities;
using ThreeBytes.Logging.Exceptions.List.Validations.Abstract;
using ThreeBytes.Logging.Exceptions.List.Validations.Concrete.Validators;

namespace ThreeBytes.Logging.Exceptions.List.Validations.Concrete.Resolvers
{
    public class ExceptionListExceptionValidatorResolver : IExceptionListExceptionValidatorResolver
    {
        private readonly Func<ExceptionListValidator> createExceptionListValidator;

        public ExceptionListExceptionValidatorResolver(Func<ExceptionListValidator> createExceptionListValidator)
        {
            this.createExceptionListValidator = createExceptionListValidator;
        }

        public IValidator<ExceptionList> CreateValidator()
        {
            return createExceptionListValidator();
        }
    }
}
