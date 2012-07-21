using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Team.Messages.Commands
{
    public interface IRenameTeamEmployeeCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string NewFirstName { get; set; }
        string NewLastName { get; set; }
        string RenamedBy { get; set; }
    }
}
