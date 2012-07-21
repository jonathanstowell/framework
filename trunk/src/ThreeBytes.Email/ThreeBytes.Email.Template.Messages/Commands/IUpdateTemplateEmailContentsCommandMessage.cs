using System;
using NServiceBus;

namespace ThreeBytes.Email.Template.Messages.Commands
{
    public interface IUpdateTemplateEmailContentsCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        bool IsHtml { get; set; }
        string Encoding { get; set; }
    }
}
