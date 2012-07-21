using System;
using NServiceBus;

namespace ThreeBytes.Email.Template.Messages.Commands
{
    public interface IRenameTemplateCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
