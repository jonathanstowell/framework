using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Team.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Team.View.Frontend.MessageHandlers
{
    public class UpdateTeamEmployeeProfileImageInternalEventMessageHandler : IHandleMessages<IUpdatedTeamEmployeeProfileImageEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public UpdateTeamEmployeeProfileImageInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IUpdatedTeamEmployeeProfileImageEventMessage message)
        {
            ConnectionManager.GetClients<TeamViewHub>().handleTeamProfileImageUpdatedEventMessage(message.Id, message.ProfileImageLocation, message.ProfileThumbnailImageLocation);
        }
    }
}