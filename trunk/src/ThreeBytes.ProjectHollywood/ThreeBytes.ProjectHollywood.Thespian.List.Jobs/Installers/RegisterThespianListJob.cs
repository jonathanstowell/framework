using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using ThreeBytes.Core.Quartz.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Jobs.Installers
{
    public class RegisterThespianListJob : IRegisterQuartzJob
    {
        public IJobDetail GetJobDetailToRun()
        {
            return new JobDetailImpl("ThreeBytes.ProjectHollywood.Thespian.List.Jobs.ThespianListJob", "ThreeBytes.ProjectHollywood", typeof(ThespianListJob));
        }

        public ITrigger GetJobTrigger()
        {
            return new CronTriggerImpl("ThreeBytes.ProjectHollywood.Thespian.List.Jobs.ThespianListJobTrigger",
                                       "ThreeBytes.ProjectHollywoodTriggers",
                                       "ThreeBytes.ProjectHollywood.Thespian.List.Jobs.ThespianListJob",
                                       "ThreeBytes.ProjectHollywood",
                                       "0 0/1 * * * ?"
                );
        }
    }
}
