namespace ThreeBytes.ProjectHollywood.Messages.News
{
    public interface IRenamedNewsArticleTitleExternalEventMessage : INewsArticleExternalEventBase
    {
        string NewTitle { get; set; }
        string RenamedBy { get; set; }
    }
}
