namespace ThreeBytes.ProjectHollywood.Messages.ExternalEvents
{
    public interface IRenamedNewsArticleTitleExternalEventMessage : INewsArticleExternalEventBase
    {
        string NewTitle { get; set; }
        string RenamedBy { get; set; }
    }
}
