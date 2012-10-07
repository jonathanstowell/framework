using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.Team;
using ThreeBytes.ProjectHollywood.Notification.Team.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.Team.Frontend.MessageHandlers
{
    public class UpdatedTeamEmployeeSummaryInternalEventMessageHandler : IHandleMessages<IUpdatedTeamEmployeeSummaryExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public UpdatedTeamEmployeeSummaryInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IUpdatedTeamEmployeeSummaryExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationTeamHub>().handleNotification(Guid.NewGuid(), "Team Employee Summary Update Complete!", message.EventDescription);
        }
    }
}
