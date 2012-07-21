using System.Collections.Generic;
using NServiceBus;

namespace ThreeBytes.Email.Messages.ExternalCommands
{
    public interface ISendTemplatedEmailExternalCommandMessage : IMessage
    {
        string ApplicationName { get; set; }
        string TemplateName { get; set; }
        string To { get; set; }
        string CC { get; set; }
        string BCC { get; set; }
        Dictionary<string, string> Model { get; set; }
    }
}