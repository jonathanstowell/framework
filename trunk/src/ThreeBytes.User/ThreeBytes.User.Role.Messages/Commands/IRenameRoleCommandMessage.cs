using System;
using NServiceBus;

namespace ThreeBytes.User.Role.Messages.Commands
{
    public interface IRenameRoleCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string NewName { get; set; }
    }
}
