using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Team.Messages.Commands
{
    public interface ICreateTeamEmployeeCommandMessage : IMessage
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string JobTitle { get; set; }
        string ProfileImageLocation { get; set; }
        string ProfileThumbnailImageLocation { get; set; }
        string Summary { get; set; }
        string CreatedBy { get; set; }
    }
}
