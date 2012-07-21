using System.IO;
using log4net.Appender;

namespace ThreeBytes.Core.Logging
{
    public class CurrentDirectoryRollingFileAppender : RollingFileAppender
    {
        public override string File
        {
            set
            {
                base.File = Path.Combine(Directory.GetCurrentDirectory(), value);
            }
        }
    }
}
