namespace ThreeBytes.Email.Messages.ExternalEvents
{
    public interface ITemplateEmailContentsUpdatedExternalEventMessage : ITemplateBaseExternalEventMessage
    {
        string Subject { get; set; }
        string Body { get; set; }
        bool IsHtml { get; set; }
        string Encoding { get; set; }
    }
}
