using System;
using NServiceBus;

namespace ThreeBytes.User.Messages.ExternalEvents
{
    public interface IUserLoggedInExternalEventMessage : IMessage
    {
        Guid UserId { get; set; }
        string Username { get; set; }
        string ApplicationName { get; set; }
        DateTime LoginDate { get; set; }
    }
}
