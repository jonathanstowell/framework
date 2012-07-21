using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Thespian.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Frontend.MessageHandlers
{
    public class ThespianCreatedEventMessageHandler : IHandleMessages<ICreatedThespianInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public ThespianCreatedEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(ICreatedThespianInternalEventMessage message)
        {
            ConnectionManager.GetClients<ThespianViewHub>().handleCreatedThespianEventMessage(message);
        }
    }
}
