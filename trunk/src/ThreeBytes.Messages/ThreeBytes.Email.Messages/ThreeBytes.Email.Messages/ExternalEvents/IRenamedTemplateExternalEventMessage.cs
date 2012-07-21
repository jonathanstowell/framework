namespace ThreeBytes.Email.Messages.ExternalEvents
{
    public interface IRenamedTemplateExternalEventMessage : ITemplateBaseExternalEventMessage
    {
        string Name { get; set; }
    }
}
