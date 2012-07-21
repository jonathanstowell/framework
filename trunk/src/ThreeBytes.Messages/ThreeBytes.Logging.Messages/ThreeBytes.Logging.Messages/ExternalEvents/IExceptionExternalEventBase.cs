using System;
using NServiceBus;

namespace ThreeBytes.Logging.Messages.ExternalEvents
{
    public interface IExceptionExternalEventBase : IMessage
    {
        Guid Id { get; set; }
    }
}
