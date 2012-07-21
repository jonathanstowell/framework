using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Team.Messages.Commands
{
    public interface IUpdateTeamEmployeeSummaryCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string NewSummary { get; set; }
        string UpdatedBy { get; set; }
    }
}
