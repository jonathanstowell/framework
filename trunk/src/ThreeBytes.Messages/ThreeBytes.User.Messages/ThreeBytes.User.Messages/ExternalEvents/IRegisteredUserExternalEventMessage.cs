using System;

namespace ThreeBytes.User.Messages.ExternalEvents
{
    public interface IRegisteredUserExternalEventMessage : IUserAuthenticationExternalEventBase
    {
        string Username { get; set; }
        string Email { get; set; }
        DateTime RegistrationDateTime { get; set; }
    }
}
