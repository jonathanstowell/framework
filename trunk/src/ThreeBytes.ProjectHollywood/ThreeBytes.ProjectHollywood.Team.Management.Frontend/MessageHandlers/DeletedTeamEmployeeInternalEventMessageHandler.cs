using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.Management.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.Management.Frontend.MessageHandlers
{
    public class DeletedTeamEmployeeInternalEventMessageHandler : IHandleMessages<IDeletedTeamEmployeeInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public DeletedTeamEmployeeInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IDeletedTeamEmployeeInternalEventMessage message)
        {
            ConnectionManager.GetClients<TeamManagementHub>().handleDeletedTeamEmployeeEventMessage(message.Id);
        }
    }
}
