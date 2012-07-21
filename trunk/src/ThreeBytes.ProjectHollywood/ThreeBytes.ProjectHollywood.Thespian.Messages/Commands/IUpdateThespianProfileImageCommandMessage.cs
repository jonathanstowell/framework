using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Thespian.Messages.Commands
{
    public interface IUpdateThespianProfileImageCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string NewProfileImageLocation { get; set; }
        string NewProfileThumbnailImageLocation { get; set; }
        string UpdatedBy { get; set; }
    }
}