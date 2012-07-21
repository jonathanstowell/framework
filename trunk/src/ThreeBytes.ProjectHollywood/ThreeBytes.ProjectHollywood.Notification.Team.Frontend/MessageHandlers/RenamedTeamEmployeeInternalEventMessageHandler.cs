using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.ExternalEvents;
using ThreeBytes.ProjectHollywood.Notification.Team.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.Team.Frontend.MessageHandlers
{
    public class RenamedTeamEmployeeInternalEventMessageHandler : IHandleMessages<IRenamedTeamEmployeeExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public RenamedTeamEmployeeInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IRenamedTeamEmployeeExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationTeamHub>().handleNotification(Guid.NewGuid(), "Team Employee Renaming Complete!", message.EventDescription);
        }
    }
}
