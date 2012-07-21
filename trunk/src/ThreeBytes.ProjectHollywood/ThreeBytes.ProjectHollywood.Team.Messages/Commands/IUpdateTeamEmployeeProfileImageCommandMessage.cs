using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Team.Messages.Commands
{
    public interface IUpdateTeamEmployeeProfileImageCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string NewProfileImageLocation { get; set; }
        string NewProfileThumbnailImageLocation { get; set; }
        string UpdatedBy { get; set; }
    }
}