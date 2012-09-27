using NServiceBus;
using NServiceBus.Hosting.Profiles;
using log4net.Appender;
using log4net.Core;

namespace ThreeBytes.Email.ServiceHost.Profiles
{
    public class IntegrationLoggingBehavior : IHandleProfile<Integration>, IConfigureLoggingForProfile<Integration>
    {
        public void ProfileActivated()
        {
            //no-op
        }

        public void Configure(IConfigureThisEndpoint specifier)
        {
            NServiceBus.Configure.With().Log4Net<ConsoleAppender>(a =>
            {
                a.Threshold = Level.Info;
            });
        }
    }
}
