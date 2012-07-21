using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.ExternalEvents;
using ThreeBytes.ProjectHollywood.Notification.News.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.News.Frontend.MessageHandlers
{
    public class RenamedNewsArticleTitleExternalEventMessageHandler : IHandleMessages<IRenamedNewsArticleTitleExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public RenamedNewsArticleTitleExternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IRenamedNewsArticleTitleExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationNewsHub>().handleNotification(Guid.NewGuid(), "News Article Renaming Complete!", message.EventDescription);
        }
    }
}
