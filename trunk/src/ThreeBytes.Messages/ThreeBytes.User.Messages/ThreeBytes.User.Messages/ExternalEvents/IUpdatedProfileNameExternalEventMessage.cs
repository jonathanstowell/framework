namespace ThreeBytes.User.Messages.ExternalEvents
{
    public interface IUpdatedProfileNameExternalEventMessage : IProfileExternalEventBase
    {
        string NewForename { get; set; }
        string NewSurname { get; set; }
    }
}
