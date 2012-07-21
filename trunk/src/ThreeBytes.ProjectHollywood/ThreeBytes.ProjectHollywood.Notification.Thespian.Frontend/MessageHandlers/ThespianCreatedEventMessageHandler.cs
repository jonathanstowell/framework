using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.ExternalEvents;
using ThreeBytes.ProjectHollywood.Notification.Thespian.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.Thespian.Frontend.MessageHandlers
{
    public class ThespianCreatedEventMessageHandler : IHandleMessages<ICreatedThespianExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public ThespianCreatedEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(ICreatedThespianExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationThespianHub>().handleNotification(Guid.NewGuid(), "Thespian Creation Complete!", message.EventDescription);
        }
    }
}
