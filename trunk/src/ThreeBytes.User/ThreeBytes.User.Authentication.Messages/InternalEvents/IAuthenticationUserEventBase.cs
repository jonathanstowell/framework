using System;
using NServiceBus;

namespace ThreeBytes.User.Authentication.Messages.InternalEvents
{
    public interface IAuthenticationUserEventBase : IMessage
    {
        Guid Id { get; set; }
        string ApplicationName { get; set; }
    }
}
