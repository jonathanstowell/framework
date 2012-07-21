using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Team.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Team.View.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<TeamViewHub>().handleRenamedTeamEmployeeEventMessage(message.Id, message.NewFirstName, message.NewLastName);
        }
    }
}
