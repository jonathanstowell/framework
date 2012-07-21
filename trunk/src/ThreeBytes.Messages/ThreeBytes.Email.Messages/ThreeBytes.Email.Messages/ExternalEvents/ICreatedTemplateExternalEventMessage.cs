namespace ThreeBytes.Email.Messages.ExternalEvents
{
    public interface ICreatedTemplateExternalEventMessage : ITemplateBaseExternalEventMessage
    {
        string Name { get; set; }
        string ApplicationName { get; set; }
        string From { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        bool IsHtml { get; set; }
        string Encoding { get; set; }
    }
}
