using System;
using NServiceBus;

namespace ThreeBytes.User.Profile.Messages.Commands
{
    public interface IUpdateProfileEmailAddressCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string NewEmail { get; set; }
    }
}
