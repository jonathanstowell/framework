using System;
using NServiceBus;

namespace ThreeBytes.User.Authentication.Messages.Commands
{
    public interface IVerifyUserCommandMessage : IMessage
    {
        string UserIdentifier { get; set; }
        Guid VerifiedCode { get; set; }
        string ApplicationName { get; set; }
    }
}
