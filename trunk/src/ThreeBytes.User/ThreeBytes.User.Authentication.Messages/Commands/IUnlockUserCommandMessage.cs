using System;
using NServiceBus;

namespace ThreeBytes.User.Authentication.Messages.Commands
{
    public interface IUnlockUserCommandMessage : IMessage
    {
        string UserIdentifier { get; set; }
        Guid UnlockCode { get; set; }
    }
}
