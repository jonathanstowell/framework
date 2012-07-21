using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Team.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Team.View.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<TeamViewHub>().handleUpdatedTeamEmployeeSummaryEventMessage(message.Id, message.NewSummary);
        }
    }
}
