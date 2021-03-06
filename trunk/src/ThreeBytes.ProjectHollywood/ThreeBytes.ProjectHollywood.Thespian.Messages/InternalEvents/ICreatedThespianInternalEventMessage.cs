﻿using ThreeBytes.ProjectHollywood.Messages.Thespian;

namespace ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents
{
    public interface ICreatedThespianInternalEventMessage : ICreatedThespianExternalEventMessage
    {
        string ProfileImageLocation { get; set; }
        string ProfileThumbnailImageLocation { get; set; }
    }
}
