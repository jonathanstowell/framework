namespace ThreeBytes.Email.Messages.ExternalEvents
{
    public interface ISentEmailMessageExternalEventMessage : IDispatchBaseExternalEventMessage
    {
        string ApplicationName { get; set; }
        string From { get; set; }
        string To { get; set; }
        string CC { get; set; }
        string BCC { get; set; }
        string Subject { get; set; }
        bool IsHtml { get; set; }
        string Encoding { get; set; }
    }
}
