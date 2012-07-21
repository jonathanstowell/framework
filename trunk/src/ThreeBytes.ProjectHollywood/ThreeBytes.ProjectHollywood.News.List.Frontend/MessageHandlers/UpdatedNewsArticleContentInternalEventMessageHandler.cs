using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.News.List.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.News.List.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<NewsListHub>().handleUpdatedNewsArticleContentEventMessage(message.Id, message.NewContent);
        }
    }
}