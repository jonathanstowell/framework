using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Team.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Team.View.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<TeamViewHub>().handleCreatedTeamEmployeeEventMessage(message);
        }
    }
}
