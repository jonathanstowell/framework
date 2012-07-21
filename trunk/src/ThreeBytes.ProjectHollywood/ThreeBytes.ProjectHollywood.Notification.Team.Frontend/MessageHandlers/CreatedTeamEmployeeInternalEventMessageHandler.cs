using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.ExternalEvents;
using ThreeBytes.ProjectHollywood.Notification.Team.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.Team.Frontend.MessageHandlers
{
    public class CreatedTeamEmployeeInternalEventMessageHandler : IHandleMessages<ICreatedTeamEmployeeExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public CreatedTeamEmployeeInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(ICreatedTeamEmployeeExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationTeamHub>().handleNotification(Guid.NewGuid(), "Team Employee Creation Complete!", message.EventDescription);
        }
    }
}
