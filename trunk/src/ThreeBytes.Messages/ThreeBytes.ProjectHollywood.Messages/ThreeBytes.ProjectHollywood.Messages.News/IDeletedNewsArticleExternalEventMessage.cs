namespace ThreeBytes.ProjectHollywood.Messages.News
{
    public interface IDeletedNewsArticleExternalEventMessage : INewsArticleExternalEventBase
    {
        string DeletedBy { get; set; }
    }
}
