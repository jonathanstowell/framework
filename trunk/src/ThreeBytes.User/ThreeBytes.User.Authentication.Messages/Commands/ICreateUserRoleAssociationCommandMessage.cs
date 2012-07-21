using System;
using NServiceBus;

namespace ThreeBytes.User.Authentication.Messages.Commands
{
    public interface ICreateUserRoleAssociationCommandMessage : IMessage
    {
        Guid UserId { get; set; }
        Guid RoleId { get; set; }
    }
}
