using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.News.Management.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.News.Management.Frontend.MessageHandlers
{
    public class UpdatedNewsArticleContentInternalEventMessageHandler : IHandleMessages<IUpdatedNewsArticleContentInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public UpdatedNewsArticleContentInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IUpdatedNewsArticleContentInternalEventMessage message)
        {
            ConnectionManager.GetClients<NewsManagementHub>().handleUpdatedNewsArticleContentEventMessage(message.Id, message.NewContent);
        }
    }
}