using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Thespian.List.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<ThespianListHub>().handleRenamedThespianEventMessage(message.Id, message.NewFirstName, message.NewLastName);
        }
    }
}
