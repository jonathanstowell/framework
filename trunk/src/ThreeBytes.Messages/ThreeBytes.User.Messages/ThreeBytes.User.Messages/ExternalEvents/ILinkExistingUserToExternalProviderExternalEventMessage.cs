using System;

namespace ThreeBytes.User.Messages.ExternalEvents
{
    public interface ILinkExistingUserToExternalProviderExternalEventMessage : IUserAuthenticationExternalEventBase
    {
        string Username { get; set; }
        string Email { get; set; }
        string ExternalProvider { get; set; }
        string ExternalIdentifier { get; set; }
        DateTime LinkDateTime { get; set; }
    }
}