namespace ThreeBytes.ProjectHollywood.Messages.ExternalEvents
{
    public interface IRenamedThespianExternalEventMessage : IThespianExternalEventBase
    {
        string NewFirstName { get; set; }
        string NewLastName { get; set; }
        string RenamedBy { get; set; }
    }
}
