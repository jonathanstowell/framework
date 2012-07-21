using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Team.Messages.Commands
{
    public interface IDeleteTeamEmployeeCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string DeletedBy { get; set; }
    }
}
