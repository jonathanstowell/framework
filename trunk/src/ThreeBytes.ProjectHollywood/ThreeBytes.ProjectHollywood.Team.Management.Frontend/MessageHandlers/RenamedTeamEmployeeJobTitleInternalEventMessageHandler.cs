using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.Management.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.Management.Frontend.MessageHandlers
{
    public class RenamedTeamEmployeeJobTitleInternalEventMessageHandler : IHandleMessages<IRenamedTeamEmployeeJobTitleInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public RenamedTeamEmployeeJobTitleInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IRenamedTeamEmployeeJobTitleInternalEventMessage message)
        {
            ConnectionManager.GetClients<TeamManagementHub>().handleRenamedTeamEmployeeJobTitleEventMessage(message.Id, message.NewJobTitle);
        }
    }
}
