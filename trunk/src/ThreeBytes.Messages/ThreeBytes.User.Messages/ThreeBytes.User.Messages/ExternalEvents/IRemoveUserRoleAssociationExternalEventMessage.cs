using System;
using NServiceBus;

namespace ThreeBytes.User.Messages.ExternalEvents
{
    public interface IRemoveUserRoleAssociationExternalEventMessage : IMessage
    {
        Guid UserId { get; set; }
        Guid RoleId { get; set; }
    }
}