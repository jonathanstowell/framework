using System;
using NServiceBus;

namespace ThreeBytes.User.Authentication.Messages.Commands
{
    public interface IRegisterUserFromExternalProviderCommandMessage : IMessage
    {
        Guid Identifier { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Token { get; set; }
        string TokenSecret { get; set; }
        string ApplicationName { get; set; }
        string ExternalIdentifier { get; set; }
        string ExternalProvider { get; set; }
    }
}
