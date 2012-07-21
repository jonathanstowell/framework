using System;
using FluentValidation;
using ThreeBytes.Logging.Exceptions.View.Entities;
using ThreeBytes.Logging.Exceptions.View.Validations.Abstract;
using ThreeBytes.Logging.Exceptions.View.Validations.Concrete.Validators;

namespace ThreeBytes.Logging.Exceptions.View.Validations.Concrete.Resolvers
{
    public class ExceptionViewExceptionValidatorResolver : IExceptionViewExceptionValidatorResolver
    {
        private readonly Func<ExceptionViewValidator> createExceptionViewValidator;

        public ExceptionViewExceptionValidatorResolver(Func<ExceptionViewValidator> createExceptionViewValidator)
        {
            this.createExceptionViewValidator = createExceptionViewValidator;
        }

        public IValidator<ExceptionView> CreateValidator()
        {
            return createExceptionViewValidator();
        }
    }
}
