using System;
using NServiceBus;

namespace ThreeBytes.Email.Template.Messages.Commands
{
    public interface IUpdateTemplateFromEmailAddressCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string From { get; set; }
    }
}
