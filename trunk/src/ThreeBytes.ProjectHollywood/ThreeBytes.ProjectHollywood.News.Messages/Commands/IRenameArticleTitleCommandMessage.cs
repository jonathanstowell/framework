using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.News.Messages.Commands
{
    public interface IRenameArticleTitleCommandMessage : IMessage
    {
        Guid Id { get; set; }
        string NewTitle { get; set; }
        string RenamedBy { get; set; }
    }
}