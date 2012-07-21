using System;
using NServiceBus;

namespace ThreeBytes.User.Authentication.Messages.Commands
{
    public interface IResetPasswordConfirmCommandMessage : IMessage
    {
        string UserIdentifier { get; set; }
        Guid ResetPasswordCode { get; set; }
        string NewPassword { get; set; }
        string NewConfirmPassword { get; set; }
        string ApplicationName { get; set; }
    }
}
