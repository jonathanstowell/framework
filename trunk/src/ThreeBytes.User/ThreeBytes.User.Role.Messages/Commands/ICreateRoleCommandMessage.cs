using NServiceBus;

namespace ThreeBytes.User.Role.Messages.Commands
{
    public interface ICreateRoleCommandMessage : IMessage
    {
        string Name { get; set; }
        string ApplicationName { get; set; }
    }
}
