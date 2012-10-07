using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.Team;
using ThreeBytes.ProjectHollywood.Notification.Team.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.Team.Frontend.MessageHandlers
{
    public class RenamedTeamEmployeeJobTitleInternalEventMessageHandler : IHandleMessages<IRenamedTeamEmployeeJobTitleExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public RenamedTeamEmployeeJobTitleInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IRenamedTeamEmployeeJobTitleExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationTeamHub>().handleNotification(Guid.NewGuid(), "Team Employee Job Title Update Complete!", message.EventDescription);
        }
    }
}
