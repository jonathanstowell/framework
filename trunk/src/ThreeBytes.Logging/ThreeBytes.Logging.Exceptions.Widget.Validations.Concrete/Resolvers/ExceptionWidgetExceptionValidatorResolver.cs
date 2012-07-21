using System;
using FluentValidation;
using ThreeBytes.Logging.Exceptions.Widget.Entities;
using ThreeBytes.Logging.Exceptions.Widget.Validations.Abstract;
using ThreeBytes.Logging.Exceptions.Widget.Validations.Concrete.Validators;

namespace ThreeBytes.Logging.Exceptions.Widget.Validations.Concrete.Resolvers
{
    public class ExceptionWidgetExceptionValidatorResolver : IExceptionWidgetExceptionValidatorResolver
    {
        private readonly Func<ExceptionWidgetValidator> createExceptionWidgetValidator;

        public ExceptionWidgetExceptionValidatorResolver(Func<ExceptionWidgetValidator> createExceptionWidgetValidator)
        {
            this.createExceptionWidgetValidator = createExceptionWidgetValidator;
        }

        public IValidator<ExceptionWidget> CreateValidator()
        {
            return createExceptionWidgetValidator();
        }
    }
}
