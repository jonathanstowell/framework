namespace ThreeBytes.ProjectHollywood.Messages.News
{
    public interface ICreatedNewsArticleExternalEventMessage : INewsArticleExternalEventBase
    {
        string Title { get; set; }
        string Content { get; set; }
        string CreatedBy { get; set; }
    }
}
