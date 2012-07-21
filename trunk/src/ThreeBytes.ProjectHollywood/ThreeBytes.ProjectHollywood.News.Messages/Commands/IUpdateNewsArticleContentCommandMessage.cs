using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.News.Messages.Commands
{
    public interface IUpdateNewsArticleContentCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string NewContent { get; set; }
        string UpdatedBy { get; set; }
    }
}
