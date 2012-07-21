using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.ExternalEvents;
using ThreeBytes.ProjectHollywood.Notification.News.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.News.Frontend.MessageHandlers
{
    public class DeletedNewsArticleExternalEventMessageHandler : IHandleMessages<IDeletedNewsArticleExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public DeletedNewsArticleExternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IDeletedNewsArticleExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationNewsHub>().handleNotification(Guid.NewGuid(), "News Article Deletion Complete!", message.EventDescription);
        }
    }
}
