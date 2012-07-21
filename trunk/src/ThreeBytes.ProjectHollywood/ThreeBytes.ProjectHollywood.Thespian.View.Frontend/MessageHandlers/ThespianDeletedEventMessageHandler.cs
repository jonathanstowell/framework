using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Thespian.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Frontend.MessageHandlers
{
    public class ThespianDeletedEventMessageHandler : IHandleMessages<IDeletedThespianInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public ThespianDeletedEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IDeletedThespianInternalEventMessage message)
        {
            ConnectionManager.GetClients<ThespianViewHub>().handleDeletedThespianEventMessage(message.Id);
        }
    }
}
