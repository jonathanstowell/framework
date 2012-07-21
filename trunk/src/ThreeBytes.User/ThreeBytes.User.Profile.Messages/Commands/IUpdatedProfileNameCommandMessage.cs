using System;
using NServiceBus;

namespace ThreeBytes.User.Profile.Messages.Commands
{
    public interface IUpdatedProfileNameCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string NewForename { get; set; }
        string NewSurname { get; set; }
    }
}
