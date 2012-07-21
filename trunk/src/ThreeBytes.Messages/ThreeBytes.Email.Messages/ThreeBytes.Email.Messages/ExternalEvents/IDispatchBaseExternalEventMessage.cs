using System;
using NServiceBus;

namespace ThreeBytes.Email.Messages.ExternalEvents
{
    public interface IDispatchBaseExternalEventMessage : IMessage
    {
        Guid Id { get; set; }
    }
}