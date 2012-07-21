using ThreeBytes.Email.Messages.ExternalEvents;

namespace ThreeBytes.Email.Dispatch.Messages.InternalEvents
{
    public interface ISentEmailMessageEventMessage : ISentEmailMessageExternalEventMessage
    {
        string Body { get; set; }
    }
}
