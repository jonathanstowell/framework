using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Team.List.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.List.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<TeamListHub>().handleTeamProfileImageUpdatedEventMessage(message.Id, message.ProfileImageLocation, message.ProfileThumbnailImageLocation);
        }
    }
}