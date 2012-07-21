using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.News.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.News.View.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<NewsViewHub>().handleCreatedNewsArticleEventMessage(message);
        }
    }
}
