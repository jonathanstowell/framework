namespace ThreeBytes.ProjectHollywood.Messages.ExternalEvents
{
    public interface IDeletedNewsArticleExternalEventMessage : INewsArticleExternalEventBase
    {
        string DeletedBy { get; set; }
    }
}
