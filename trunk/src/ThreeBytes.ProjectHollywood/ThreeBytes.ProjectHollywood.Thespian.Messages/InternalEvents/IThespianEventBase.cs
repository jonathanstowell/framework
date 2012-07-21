using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents
{
    public interface IThespianEventBase : IMessage
    {
        Guid Id { get; set; }
    }
}
