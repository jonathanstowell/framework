using System;
using ThreeBytes.Core.Email.Abstract;

namespace ThreeBytes.Core.Email.Exceptions
{
    public class AsyncServiceEmailException : Exception
    {
        private readonly ISendEmailResult results;
        public ISendEmailResult Results { get { return results; } }

        public AsyncServiceEmailException(string message, Exception innerException, ISendEmailResult results)
            : base(message, innerException)
        {
            if (results == null)
                throw new ArgumentNullException("results");

            this.results = results;
        }

        public AsyncServiceEmailException(string message, ISendEmailResult results)
            : base(message)
        {
            if (results == null)
                throw new ArgumentNullException("results");

            this.results = results;
        }
    }
}
