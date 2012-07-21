using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.ExternalEvents;
using ThreeBytes.ProjectHollywood.Notification.Thespian.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.Thespian.Frontend.MessageHandlers
{
    public class ThespianRenamedInternalEventMessageHandler : IHandleMessages<IRenamedThespianExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public ThespianRenamedInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IRenamedThespianExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationThespianHub>().handleNotification(Guid.NewGuid(), "Thespian Renaming Complete!", message.EventDescription);
        }
    }
}
