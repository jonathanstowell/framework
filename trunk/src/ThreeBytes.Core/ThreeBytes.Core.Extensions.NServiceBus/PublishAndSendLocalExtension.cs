using System;
using NServiceBus;

namespace ThreeBytes.Core.Extensions.NServiceBus
{
    public static class PublishAndSendLocalExtension
    {
        public static void PublishAndSendLocal<T>(this IBus bus, Action<T> create) where T : IMessage
        {
            bus.Publish(create);
            bus.SendLocal(create);
        }

        public static void PublishAndSendLocal<T>(this IBus bus, T message) where T : IMessage
        {
            bus.Publish(message);
            bus.SendLocal(message);
        }
    }
}
