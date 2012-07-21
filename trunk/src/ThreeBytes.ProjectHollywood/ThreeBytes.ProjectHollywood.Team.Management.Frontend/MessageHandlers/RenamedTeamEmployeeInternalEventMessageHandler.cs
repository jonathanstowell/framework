using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.Management.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.Management.Frontend.MessageHandlers
{
    public class RenamedTeamEmployeeInternalEventMessageHandler : IHandleMessages<IRenamedTeamEmployeeInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public RenamedTeamEmployeeInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IRenamedTeamEmployeeInternalEventMessage message)
        {
            ConnectionManager.GetClients<TeamManagementHub>().handleRenamedTeamEmployeeEventMessage(message.Id, message.NewFirstName, message.NewLastName);
            ConnectionManager.GetClients<TeamManagementDeletionHub>().handleRenamedTeamEmployeeEventMessage(message.Id, message.NewFirstName, message.NewLastName);
        }
    }
}
