namespace ThreeBytes.ProjectHollywood.Messages.News
{
    public interface IUpdatedNewsArticleContentExternalEventMessage : INewsArticleExternalEventBase
    {
        string NewContent { get; set; }
        string UpdatedBy { get; set; }
    }
}
