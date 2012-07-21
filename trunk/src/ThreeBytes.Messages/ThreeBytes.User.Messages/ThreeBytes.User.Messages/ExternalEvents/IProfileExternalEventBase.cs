using System;
using NServiceBus;

namespace ThreeBytes.User.Messages.ExternalEvents
{
    public interface IProfileExternalEventBase : IMessage
    {
        Guid Id { get; set; }
        string ApplicationName { get; set; }
    }
}
