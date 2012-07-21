using NServiceBus;

namespace ThreeBytes.Email.Messages.ExternalCommands
{
    public interface ISendEmailExternalCommandMessage : IMessage
    {
        string ApplicationName { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        string From { get; set; }
        string To { get; set; }
        string CC { get; set; }
        string BCC { get; set; }
        bool IsHtml { get; set; }
        string Encoding { get; set; }
    }
}
