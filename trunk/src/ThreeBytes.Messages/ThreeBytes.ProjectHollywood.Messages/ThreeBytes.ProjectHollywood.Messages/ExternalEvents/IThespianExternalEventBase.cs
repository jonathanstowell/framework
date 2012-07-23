﻿using System;
using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Messages.ExternalEvents
{
    public interface IThespianExternalEventBase : IMessage
    {
        Guid Id { get; set; }
        string EventDescription { get; set; }
    }
}