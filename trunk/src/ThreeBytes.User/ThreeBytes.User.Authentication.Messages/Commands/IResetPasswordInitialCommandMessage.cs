using NServiceBus;

namespace ThreeBytes.User.Authentication.Messages.Commands
{
    public interface IResetPasswordInitialCommandMessage : IMessage
    {
        string UserIdentifier { get; set; }
        string ApplicationName { get; set; }
    }
}
