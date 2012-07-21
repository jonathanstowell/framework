using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.News.Management.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.News.Management.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<NewsManagementHub>().handleDeletedNewsArticleEventMessage(message.Id);
        }
    }
}
