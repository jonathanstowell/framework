using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Thespian.Messages.Commands
{
    public interface IDeleteThespianCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string DeletedBy { get; set; }
    }
}
