using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<ThespianManagementHub>().handleRenamedThespianEventMessage(message.Id, message.NewFirstName, message.NewLastName);
            ConnectionManager.GetClients<ThespianManagementDeletionHub>().handleRenamedThespianEventMessage(message.Id, message.NewFirstName, message.NewLastName);
        }
    }
}
