using NServiceBus;

namespace ThreeBytes.Email.Template.Messages.Commands
{
    public interface ICreateTemplateCommandMessage : IMessage
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
