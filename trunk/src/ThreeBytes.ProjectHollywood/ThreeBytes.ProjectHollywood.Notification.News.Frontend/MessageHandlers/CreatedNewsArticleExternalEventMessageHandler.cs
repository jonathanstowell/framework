using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.News;
using ThreeBytes.ProjectHollywood.Notification.News.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.News.Frontend.MessageHandlers
{
    public class CreatedNewsArticleExternalEventMessageHandler : IHandleMessages<ICreatedNewsArticleExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public CreatedNewsArticleExternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(ICreatedNewsArticleExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationNewsHub>().handleNotification(Guid.NewGuid(), "News Article Creation Complete!", message.EventDescription);
        }
    }
}
