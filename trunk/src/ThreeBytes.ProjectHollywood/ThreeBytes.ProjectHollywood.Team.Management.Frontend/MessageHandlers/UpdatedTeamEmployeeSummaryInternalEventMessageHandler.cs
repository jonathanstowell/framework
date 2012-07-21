using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.Management.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.Management.Frontend.MessageHandlers
{
    public class UpdatedTeamEmployeeSummaryInternalEventMessageHandler : IHandleMessages<IUpdatedTeamEmployeeSummaryInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public UpdatedTeamEmployeeSummaryInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IUpdatedTeamEmployeeSummaryInternalEventMessage message)
        {
            ConnectionManager.GetClients<TeamManagementHub>().handleUpdatedTeamEmployeeSummaryEventMessage(message.Id, message.NewSummary);
        }
    }
}
