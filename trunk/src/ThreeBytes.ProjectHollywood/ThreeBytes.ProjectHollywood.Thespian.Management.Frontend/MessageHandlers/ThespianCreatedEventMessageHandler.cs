using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<ThespianManagementHub>().handleCreatedThespianEventMessage(message);
        }
    }
}
