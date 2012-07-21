using System;
using NServiceBus;
using ThreeBytes.Logging.Exceptions.Messages.InternalEvents;
using ThreeBytes.Logging.Exceptions.Widget.Entities;
using ThreeBytes.Logging.Exceptions.Widget.Service.Abstract;

namespace ThreeBytes.Logging.Exceptions.Widget.Backend.MessageHandlers
{
    public class LogExceptionEventMessageHandler : IHandleMessages<ILoggedExceptionInternalEventMessage>
    {
        private readonly IExceptionWidgetService service;

        public LogExceptionEventMessageHandler(IExceptionWidgetService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        public void Handle(ILoggedExceptionInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ExceptionWidget exception = new ExceptionWidget();

            exception.Id = message.Id;
            exception.Message = message.Message;
            exception.Source = message.Source;

            service.Create(exception);
        }
    }
}
