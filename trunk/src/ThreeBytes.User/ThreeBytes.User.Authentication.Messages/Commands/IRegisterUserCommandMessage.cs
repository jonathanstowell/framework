using NServiceBus;

namespace ThreeBytes.User.Authentication.Messages.Commands
{
    public interface IRegisterUserCommandMessage : IMessage
    {
        string Username { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
        string ApplicationName { get; set; }
    }
}