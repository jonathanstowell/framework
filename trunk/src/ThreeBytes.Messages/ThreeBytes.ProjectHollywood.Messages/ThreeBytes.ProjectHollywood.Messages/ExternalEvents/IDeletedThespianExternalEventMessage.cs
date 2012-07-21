using System;

namespace ThreeBytes.ProjectHollywood.Messages.ExternalEvents
{
    public interface IDeletedThespianExternalEventMessage : IThespianExternalEventBase
    {
        string DeletedBy { get; set; }
    }
}
