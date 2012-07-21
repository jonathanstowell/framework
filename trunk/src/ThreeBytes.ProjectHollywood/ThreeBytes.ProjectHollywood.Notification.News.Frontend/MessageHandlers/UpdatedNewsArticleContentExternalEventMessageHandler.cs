using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Messages.ExternalEvents;
using ThreeBytes.ProjectHollywood.Notification.News.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Notification.News.Frontend.MessageHandlers
{
    public class UpdatedNewsArticleContentExternalEventMessageHandler : IHandleMessages<IUpdatedNewsArticleContentExternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public UpdatedNewsArticleContentExternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IUpdatedNewsArticleContentExternalEventMessage message)
        {
            ConnectionManager.GetClients<NotificationNewsHub>().handleNotification(Guid.NewGuid(), "News Article Content Update Complete!", message.EventDescription);
        }
    }
}