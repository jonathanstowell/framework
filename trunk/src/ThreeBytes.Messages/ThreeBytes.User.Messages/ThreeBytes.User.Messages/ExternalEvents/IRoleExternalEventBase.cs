using System;
using NServiceBus;

namespace ThreeBytes.User.Messages.ExternalEvents
{
    public interface IRoleExternalEventBase : IMessage
    {
        Guid Id { get; set; }
        string ApplicationName { get; set; }
    }
}
