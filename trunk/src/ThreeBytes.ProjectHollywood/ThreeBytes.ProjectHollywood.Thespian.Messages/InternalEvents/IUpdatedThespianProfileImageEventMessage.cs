namespace ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents
{
    public interface IUpdatedThespianProfileImageEventMessage : IThespianEventBase
    {
        string ProfileImageLocation { get; set; }
        string ProfileThumbnailImageLocation { get; set; }
        string UpdatedBy { get; set; }
        string EventDescription { get; set; }
    }
}