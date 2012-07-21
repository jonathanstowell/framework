using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents
{
    public interface IUpdatedTeamEmployeeProfileImageEventMessage : IMessage
    {
        Guid Id { get; set; }
        string ProfileImageLocation { get; set; }
        string ProfileThumbnailImageLocation { get; set; }
        string UpdatedBy { get; set; }
        string EventDescription { get; set; }
    }
}