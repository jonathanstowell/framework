using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.News.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.News.View.Frontend.MessageHandlers
{
    public class DeletedNewsArticleInternalEventMessageHandler : IHandleMessages<IDeletedNewsArticleInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public DeletedNewsArticleInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IDeletedNewsArticleInternalEventMessage message)
        {
            ConnectionManager.GetClients<NewsViewHub>().handleDeletedNewsArticleEventMessage(message.Id);
        }
    }
}
