using System;
using NServiceBus;

namespace ThreeBytes.User.Authentication.Messages.Commands
{
    public interface IUserEnteredIncorrectPasswordCommandMessage : IMessage
    {
        Guid Id { get; set; }
    }
}
