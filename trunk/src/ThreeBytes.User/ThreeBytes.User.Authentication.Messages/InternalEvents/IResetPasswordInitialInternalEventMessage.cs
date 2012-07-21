using System;

namespace ThreeBytes.User.Authentication.Messages.InternalEvents
{
    public interface IResetPasswordInitialInternalEventMessage : IAuthenticationUserEventBase
    {
        string Username { get; set; }
        string Email { get; set; }
        Guid ResetPasswordCode { get; set; }
    }
}
