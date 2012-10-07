using NServiceBus;
using NServiceBus.Hosting.Profiles;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;

namespace ThreeBytes.ProjectHollywood.Thespian.ServiceHost.Profiles
{
    public class ProductionLoggingBehavior : IHandleProfile<Production>, IConfigureLoggingForProfile<Production>
    {
        public void ProfileActivated()
        {
            //no-op
        }

        public void Configure(IConfigureThisEndpoint specifier)
        {
            NServiceBus.Configure.With().Log4Net<RollingFileAppender>(a =>
            {
                a.File = "servicehost.log";
                a.AppendToFile = true;
                a.RollingStyle = RollingFileAppender.RollingMode.Size;
                a.Threshold = Level.Error;
                a.MaxSizeRollBackups = 10;
                a.MaxFileSize = 10 * 1024 * 1024; // 10MB
                a.StaticLogFileName = true;
                a.Layout = new PatternLayout("%date [%thread] %-5level %logger [%property{NDC}] - %message%newline");
            });
        }
    }
}
