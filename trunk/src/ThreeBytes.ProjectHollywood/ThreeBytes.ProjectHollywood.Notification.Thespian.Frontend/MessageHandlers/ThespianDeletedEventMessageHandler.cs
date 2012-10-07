using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.Thespian;
using ThreeBytes.ProjectHollywood.Notification.Thespian.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.Thespian.Frontend.MessageHandlers
{
    public class ThespianDeletedEventMessageHandler : IHandleMessages<IDeletedThespianExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public ThespianDeletedEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IDeletedThespianExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationThespianHub>().handleNotification(Guid.NewGuid(), "Thespian Deletion Complete!", message.EventDescription);
        }
    }
}
