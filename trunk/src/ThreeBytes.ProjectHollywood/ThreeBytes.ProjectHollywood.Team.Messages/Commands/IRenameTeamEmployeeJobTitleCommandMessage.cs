using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Team.Messages.Commands
{
    public interface IRenameTeamEmployeeJobTitleCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string NewJobTitle { get; set; }
        string RenamedBy { get; set; }
    }
}
