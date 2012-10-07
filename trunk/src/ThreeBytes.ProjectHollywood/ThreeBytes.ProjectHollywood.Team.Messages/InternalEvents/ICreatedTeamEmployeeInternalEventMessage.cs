using ThreeBytes.ProjectHollywood.Messages.Team;

namespace ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents
{
    public interface ICreatedTeamEmployeeInternalEventMessage : ICreatedTeamEmployeeExternalEventMessage
    {
        string ProfileImageLocation { get; set; }
        string ProfileThumbnailImageLocation { get; set; }
    }
}
