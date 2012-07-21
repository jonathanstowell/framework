namespace ThreeBytes.User.Messages.ExternalEvents
{
    public interface IUpdatedProfileEmailAddressExternalEventMessage : IProfileExternalEventBase
    {
        string NewEmail { get; set; }
    }
}
