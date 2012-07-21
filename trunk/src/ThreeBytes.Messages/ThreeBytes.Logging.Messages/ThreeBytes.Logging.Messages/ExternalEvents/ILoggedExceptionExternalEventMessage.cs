namespace ThreeBytes.Logging.Messages.ExternalEvents
{
    public interface ILoggedExceptionExternalEventMessage : IExceptionExternalEventBase
    {
        string Message { get; set; }
        string Source { get; set; }
        string StackTrace { get; set; }
        string InnerException { get; set; }
    }
}
