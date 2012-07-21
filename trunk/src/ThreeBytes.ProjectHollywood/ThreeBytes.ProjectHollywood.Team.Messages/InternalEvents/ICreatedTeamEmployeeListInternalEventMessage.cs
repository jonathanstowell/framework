using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents
{
    public interface ICreatedTeamEmployeeListInternalEventMessage : IMessage
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string JobTitle { get; set; }
    }
}