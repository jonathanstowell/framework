using NServiceBus;

namespace ThreeBytes.User.Messages.ExternalEvents
{
    public interface ISetupUserSystemExternalEventMessage : IMessage
    {
        string ApplicationName { get; set; }
    }
}
