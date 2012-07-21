using Common.Logging;
using Quartz;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Jobs
{
    public class ThespianListJob : IJob
    {
        private readonly ILog logger;

        public ThespianListJob()
        {
            logger = LogManager.GetLogger(GetType());
        }

        public void Execute(IJobExecutionContext context)
        {
            logger.Info("Executing Thespian List Job");
        }
    }
}
