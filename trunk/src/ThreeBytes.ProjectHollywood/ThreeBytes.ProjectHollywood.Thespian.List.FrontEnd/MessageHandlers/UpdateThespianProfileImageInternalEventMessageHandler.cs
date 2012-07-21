using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Thespian.List.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Frontend.MessageHandlers
{
    public class UpdateThespianProfileImageInternalEventMessageHandler : IHandleMessages<IUpdatedThespianProfileImageEventMessage>
    {
        public IConnectionManager ConnectionManager;

        public UpdateThespianProfileImageInternalEventMessageHandler(IConnectionManager connectionManager)
        {
            if (connectionManager == null)
                throw new ArgumentNullException("connectionManager");

            ConnectionManager = connectionManager;
        }

        public void Handle(IUpdatedThespianProfileImageEventMessage message)
        {
            ConnectionManager.GetClients<ThespianListHub>().handleThespianProfileImageUpdatedEventMessage(message.Id, message.ProfileImageLocation, message.ProfileThumbnailImageLocation);
        }
    }
}