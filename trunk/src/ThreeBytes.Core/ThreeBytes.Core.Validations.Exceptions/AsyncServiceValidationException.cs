using System;
using FluentValidation.Results;

namespace ThreeBytes.Core.Validations.Exceptions
{
    public class AsyncServiceValidationException : Exception
    {
        private readonly ValidationResult results;
        public ValidationResult Results { get { return results; } }

        public AsyncServiceValidationException(string message, Exception innerException, ValidationResult results)
            : base(message, innerException)
        {
            this.results = results;
        }

        public AsyncServiceValidationException(string message, ValidationResult results)
            : base(message)
        {
            this.results = results;
        }
    }
}
