using System;
using NServiceBus;

namespace ThreeBytes.User.Authentication.Messages.Commands
{
    public interface ILoggedUserInUsingOAuthProviderCommandMessage : IMessage
    {
        Guid UserId { get; set; }
        string Username { get; set; }
        string ApplicationName { get; set; }
        DateTime LoginDate { get; set; }
    }
}