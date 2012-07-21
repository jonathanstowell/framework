using System;
using NServiceBus;
using ThreeBytes.Logging.Exceptions.Messages.InternalEvents;
using ThreeBytes.Logging.Exceptions.View.Entities;
using ThreeBytes.Logging.Exceptions.View.Service.Abstract;

namespace ThreeBytes.Logging.Exceptions.View.Backend.MessageHandlers
{
    public class LogExceptionEventMessageHandler : IHandleMessages<ILoggedExceptionInternalEventMessage>
    {
        private readonly IExceptionViewService service;

        public LogExceptionEventMessageHandler(IExceptionViewService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        public void Handle(ILoggedExceptionInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ExceptionView exception = new ExceptionView();

            exception.Id = message.Id;
            exception.Source = message.Source;
            exception.Message = message.Message;
            exception.StackTrace = message.StackTrace;
            exception.InnerException = message.InnerException;

            service.Create(exception);
        }
    }
}
