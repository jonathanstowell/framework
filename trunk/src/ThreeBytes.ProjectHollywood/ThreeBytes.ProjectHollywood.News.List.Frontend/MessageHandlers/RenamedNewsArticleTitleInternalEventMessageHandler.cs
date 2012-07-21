using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.News.List.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.News.List.Frontend.MessageHandlers
{
    public class RenamedNewsArticleTitleInternalEventMessageHandler : IHandleMessages<IRenamedNewsArticleTitleInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public RenamedNewsArticleTitleInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IRenamedNewsArticleTitleInternalEventMessage message)
        {
            ConnectionManager.GetClients<NewsListHub>().handleRenamedNewsArticleTitleEventMessage(message.Id, message.NewTitle);
        }
    }
}
