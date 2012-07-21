using System;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Logging.Exceptions.Management.Entities;
using ThreeBytes.Logging.Messages.ExternalEvents;

namespace ThreeBytes.Logging.Exceptions.Management.Backend.MessageHandlers
{
    public class LogExceptionExternalCommandMessageHandler : IHandleMessages<ILogExceptionExternalCommandMessage>
    {
        public IBus Bus { get; set; }

        public LogExceptionExternalCommandMessageHandler()
        {
        }

        public void Handle(ILogExceptionExternalCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ExceptionManagement exception = new ExceptionManagement();

            exception.Id = Guid.NewGuid();
            exception.InnerException = message.InnerException;
            exception.Message = message.Message;
            exception.Source = message.Source;
            exception.StackTrace = message.StackTrace;

            Bus.PublishAndSendLocal<Messages.InternalEvents.ILoggedExceptionInternalEventMessage>(x =>
                                                                           {
                                                                               x.Id = exception.Id;
                                                                               x.InnerException = exception.InnerException;
                                                                               x.Message = exception.Message;
                                                                               x.Source = exception.Source;
                                                                               x.StackTrace = exception.StackTrace;
                                                                           });
        }
    }
}
