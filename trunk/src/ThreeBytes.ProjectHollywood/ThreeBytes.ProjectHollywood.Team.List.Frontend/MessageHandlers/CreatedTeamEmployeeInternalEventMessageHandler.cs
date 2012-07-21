using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.List.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.List.Frontend.MessageHandlers
{
    public class CreatedTeamEmployeeInternalEventMessageHandler : IHandleMessages<ICreatedTeamEmployeeInternalEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public CreatedTeamEmployeeInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(ICreatedTeamEmployeeInternalEventMessage message)
        {
            ConnectionManager.GetClients<TeamListHub>().handleCreatedTeamEmployeeEventMessage(message);
        }
    }
}
