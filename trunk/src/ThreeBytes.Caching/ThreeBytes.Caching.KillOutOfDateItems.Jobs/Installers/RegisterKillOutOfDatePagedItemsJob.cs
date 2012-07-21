using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using ThreeBytes.Core.Quartz.Abstract;

namespace ThreeBytes.Caching.KillOutOfDateItems.Jobs.Installers
{
    public class RegisterKillOutOfDatePagedItemsJob : IRegisterQuartzJob
    {
        public IJobDetail GetJobDetailToRun()
        {
            return new JobDetailImpl("ThreeBytes.Caching.KillOutOfDateItems.Jobs.KillOutOfDatePagedItemsJob", "ThreeBytes.Caching", typeof(KillOutOfDatePagedItemsJob));
        }

        public ITrigger GetJobTrigger()
        {
            return new CronTriggerImpl("ThreeBytes.Caching.KillOutOfDateItems.Jobs.KillOutOfDatePagedItemsJobTrigger",
                                       "ThreeBytes.CachingTriggers",
                                       "ThreeBytes.Caching.KillOutOfDateItems.Jobs.KillOutOfDatePagedItemsJob",
                                       "ThreeBytes.Caching",
                                       "0 0/1 * * * ?"
                );
        }
    }
}
