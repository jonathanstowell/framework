using System;
using NServiceBus;

namespace ThreeBytes.Email.Messages.ExternalEvents
{
    public interface ITemplateBaseExternalEventMessage : IMessage
    {
        Guid Id { get; set; }
    }
}
