using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Thespian.Messages.Commands
{
    public interface IRenameThespianCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string NewFirstName { get; set; }
        string NewLastName { get; set; }
        string RenamedBy { get; set; }
    }
}
