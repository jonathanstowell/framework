using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Thespian.List.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<ThespianListHub>().handleCreatedThespianEventMessage(message);
        }
    }
}
