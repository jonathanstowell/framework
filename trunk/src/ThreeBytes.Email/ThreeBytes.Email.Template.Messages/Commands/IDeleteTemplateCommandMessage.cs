using System;
using NServiceBus;

namespace ThreeBytes.Email.Template.Messages.Commands
{
    public interface IDeleteTemplateCommandMessage : IMessage
    {
        Guid Id { get; set; }
    }
}
