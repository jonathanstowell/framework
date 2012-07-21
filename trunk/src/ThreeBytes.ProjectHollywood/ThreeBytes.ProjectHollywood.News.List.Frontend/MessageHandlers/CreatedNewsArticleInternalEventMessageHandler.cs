using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.News.List.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.News.List.Frontend.MessageHandlers
{
    public class CreatedNewsArticleInternalEventMessageHandler : IHandleMessages<ICreatedNewsArticleInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public CreatedNewsArticleInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(ICreatedNewsArticleInternalEventMessage message)
        {
            ConnectionManager.GetClients<NewsListHub>().handleCreatedNewsArticleEventMessage(message);
        }
    }
}
