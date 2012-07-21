using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using ThreeBytes.Core.Quartz.Abstract;

namespace ThreeBytes.Caching.KillOutOfDateItems.Jobs.Installers
{
    public class RegisterKillOutOfDateMostRecentItemsJob : IRegisterQuartzJob
    {
        public IJobDetail GetJobDetailToRun()
        {
            return new JobDetailImpl("ThreeBytes.Caching.KillOutOfDateItems.Jobs.KillOutOfDateMostRecentItemsJob", "ThreeBytes.Caching", typeof(KillOutOfDateMostRecentItemsJob));
        }

        public ITrigger GetJobTrigger()
        {
            return new CronTriggerImpl("ThreeBytes.Caching.KillOutOfDateItems.Jobs.KillOutOfDateMostRecentItemsJobTrigger",
                                       "ThreeBytes.CachingTriggers",
                                       "ThreeBytes.Caching.KillOutOfDateItems.Jobs.KillOutOfDateMostRecentItemsJob",
                                       "ThreeBytes.Caching",
                                       "0 0/1 * * * ?"
                );
        }
    }
}