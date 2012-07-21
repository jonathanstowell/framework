using System;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Authentication.Messages.InternalEvents
{
    public interface IRegisterExistingExternalUserInternalEventMessage : IRegisterExistingExternalUserExternalEventMessage
    {
        string Password { get; set; }
        Guid VerifiedCode { get; set; }
    }
}