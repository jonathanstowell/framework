using System;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Authentication.Messages.InternalEvents
{
    public interface ILockUserOutInternalEventMessage : ILockUserOutExternalEventMessage
    {
        string Username { get; set; }
        string Email { get; set; }
        Guid UnlockCode { get; set; }
    }
}
