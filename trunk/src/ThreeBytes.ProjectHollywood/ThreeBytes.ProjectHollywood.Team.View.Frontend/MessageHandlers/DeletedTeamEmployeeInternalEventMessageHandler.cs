using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Team.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Team.View.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<TeamViewHub>().handleDeletedTeamEmployeeEventMessage(message.Id);
        }
    }
}
