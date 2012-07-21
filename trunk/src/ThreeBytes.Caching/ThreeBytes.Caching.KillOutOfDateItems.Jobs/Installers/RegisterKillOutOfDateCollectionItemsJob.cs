using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using ThreeBytes.Core.Quartz.Abstract;

namespace ThreeBytes.Caching.KillOutOfDateItems.Jobs.Installers
{
    public class RegisterKillOutOfDateCollectionItemsJob : IRegisterQuartzJob
    {
        public IJobDetail GetJobDetailToRun()
        {
            return new JobDetailImpl("ThreeBytes.Caching.KillOutOfDateItems.Jobs.KillOutOfDateCollectionItemsJob", "ThreeBytes.Caching", typeof(KillOutOfDateCollectionItemsJob));
        }

        public ITrigger GetJobTrigger()
        {
            return new CronTriggerImpl("ThreeBytes.Caching.KillOutOfDateItems.Jobs.KillOutOfDateCollectionItemsJobTrigger",
                                       "ThreeBytes.CachingTriggers",
                                       "ThreeBytes.Caching.KillOutOfDateItems.Jobs.KillOutOfDateCollectionItemsJob",
                                       "ThreeBytes.Caching",
                                       "0 0/1 * * * ?"
                );
        }
    }
}