namespace ThreeBytes.ProjectHollywood.Messages.Thespian
{
    public interface IRenamedThespianExternalEventMessage : IThespianExternalEventBase
    {
        string NewFirstName { get; set; }
        string NewLastName { get; set; }
        string RenamedBy { get; set; }
    }
}
