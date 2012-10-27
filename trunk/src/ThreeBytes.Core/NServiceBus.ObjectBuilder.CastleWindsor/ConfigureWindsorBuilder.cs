using Castle.Windsor;
using NServiceBus.ObjectBuilder.Common;
using NServiceBus.ObjectBuilder.Common.Config;

namespace NServiceBus.ObjectBuilder.CastleWindsor
{
    public static class ConfigureWindsorBuilder
    {
        public static Configure CastleWindsorBuilder(this Configure config)
        {
            ConfigureCommon.With(config, (IContainer)new WindsorObjectBuilder());
            return config;
        }

        public static Configure CastleWindsorBuilder(this Configure config, IWindsorContainer container)
        {
            ConfigureCommon.With(config, (IContainer)new WindsorObjectBuilder(container));
            return config;
        }
    }
}
