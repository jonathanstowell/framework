using NServiceBus;

namespace ThreeBytes.ProjectHollywood.News.Messages.Commands
{
    public interface ICreateNewsArticleCommandMessage : IMessage
    {
        string Title { get; set; }
        string Content { get; set; }
        string CreatedBy { get; set; }
    }
}
