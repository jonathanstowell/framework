using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.News.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.News.View.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<NewsViewHub>().handleUpdatedNewsArticleContentEventMessage(message.Id, message.NewContent);
        }
    }
}