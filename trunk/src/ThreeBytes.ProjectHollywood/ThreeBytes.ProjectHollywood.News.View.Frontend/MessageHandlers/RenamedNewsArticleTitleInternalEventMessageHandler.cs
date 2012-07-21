using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.News.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.News.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.News.View.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<NewsViewHub>().handleRenamedNewsArticleTitleEventMessage(message.Id, message.NewTitle);
        }
    }
}
