using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.Team;
using ThreeBytes.ProjectHollywood.Notification.Team.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.Team.Frontend.MessageHandlers
{
    public class DeletedTeamEmployeeInternalEventMessageHandler : IHandleMessages<IDeletedTeamEmployeeExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public DeletedTeamEmployeeInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IDeletedTeamEmployeeExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationTeamHub>().handleNotification(Guid.NewGuid(), "Team Employee Deletion Complete!", message.EventDescription);
        }
    }
}
