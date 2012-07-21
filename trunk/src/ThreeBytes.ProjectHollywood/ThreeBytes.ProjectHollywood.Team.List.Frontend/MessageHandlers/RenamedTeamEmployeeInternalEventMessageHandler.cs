using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.List.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.List.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<TeamListHub>().handleRenamedTeamEmployeeEventMessage(message.Id, message.NewFirstName, message.NewLastName);
        }
    }
}
