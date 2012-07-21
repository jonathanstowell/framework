using NServiceBus;

namespace ThreeBytes.Core.NServiceBus.ObjectBuilder.CastleWindsor
{
    internal class InstanceReleasingMessageModule : IMessageModule
    {
        public static WindsorObjectBuilder Builder { get; set; }

        void IMessageModule.HandleBeginMessage()
        {
        }

        void IMessageModule.HandleEndMessage()
        {
            InstanceReleasingMessageModule.Builder.ReleaseResolvedInstances();
        }

        void IMessageModule.HandleError()
        {
            InstanceReleasingMessageModule.Builder.ReleaseResolvedInstances();
        }
    }
}
