using System;
using NServiceBus;
using SignalR;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Thespian.View.Frontend.Hubs;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Frontend.MessageHandlers
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
            ConnectionManager.GetClients<ThespianViewHub>().handleThespianProfileImageUpdatedEventMessage(message.Id, message.ProfileImageLocation, message.ProfileThumbnailImageLocation);
        }
    }
}