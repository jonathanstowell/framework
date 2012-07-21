namespace ThreeBytes.ProjectHollywood.Messages.ExternalEvents
{
    public interface IUpdatedNewsArticleContentExternalEventMessage : INewsArticleExternalEventBase
    {
        string NewContent { get; set; }
        string UpdatedBy { get; set; }
    }
}
