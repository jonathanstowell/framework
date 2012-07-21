using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Team.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Team.View.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<TeamViewHub>().handleRenamedTeamEmployeeJobTitleEventMessage(message.Id, message.NewJobTitle);
        }
    }
}
