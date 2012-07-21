using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Thespian.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Frontend.MessageHandlers
{
    public class ThespianRenamedInternalEventMessageHandler : IHandleMessages<IRenamedThespianInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public ThespianRenamedInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IRenamedThespianInternalEventMessage message)
        {
            ConnectionManager.GetClients<ThespianViewHub>().handleRenamedThespianEventMessage(message.Id, message.NewFirstName, message.NewLastName);
        }
    }
}
