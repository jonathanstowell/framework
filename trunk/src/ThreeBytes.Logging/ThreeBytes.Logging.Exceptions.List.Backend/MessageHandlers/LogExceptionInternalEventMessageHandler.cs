using System;
using NServiceBus;
using ThreeBytes.Logging.Exceptions.List.Entities;
using ThreeBytes.Logging.Exceptions.List.Service.Abstract;
using ThreeBytes.Logging.Exceptions.Messages.InternalEvents;

namespace ThreeBytes.Logging.Exceptions.List.Backend.MessageHandlers
{
    public class LogExceptionInternalEventMessageHandler : IHandleMessages<ILoggedExceptionInternalEventMessage>
    {
        private readonly IExceptionListService service;

        public LogExceptionInternalEventMessageHandler(IExceptionListService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        public void Handle(ILoggedExceptionInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ExceptionList exception = new ExceptionList {Id = message.Id, Message = message.Message, Source = message.Source};

            service.Create(exception);
        }
    }
}
