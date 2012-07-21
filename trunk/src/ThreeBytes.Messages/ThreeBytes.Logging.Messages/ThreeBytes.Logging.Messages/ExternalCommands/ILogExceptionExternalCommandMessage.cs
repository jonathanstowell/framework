using NServiceBus;

namespace ThreeBytes.Logging.Messages.ExternalEvents
{
    public interface ILogExceptionExternalCommandMessage : IMessage
    {
        string Message { get; set; }
        string Source { get; set; }
        string StackTrace { get; set; }
        string InnerException { get; set; }
    }
}