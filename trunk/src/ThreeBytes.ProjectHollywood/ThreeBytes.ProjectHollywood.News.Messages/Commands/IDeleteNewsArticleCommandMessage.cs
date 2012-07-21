using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.News.Messages.Commands
{
    public interface IDeleteNewsArticleCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string DeletedBy { get; set; }
    }
}
