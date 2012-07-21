using System;
using ThreeBytes.Core.Email.Abstract;

namespace ThreeBytes.Core.Email.Exceptions
{
    public class AsyncServiceBatchEmailException : Exception
    {
        private readonly ISendBatchEmailResult results;
        public ISendBatchEmailResult Results { get { return results; } }

        public AsyncServiceBatchEmailException(string message, Exception innerException, ISendBatchEmailResult results)
            : base(message, innerException)
        {
            if (results == null)
                throw new ArgumentNullException("results");

            this.results = results;
        }

        public AsyncServiceBatchEmailException(string message, ISendBatchEmailResult results)
            : base(message)
        {
            if (results == null)
                throw new ArgumentNullException("results");

            this.results = results;
        }
    }
}
