using Quartz;

namespace ThreeBytes.Core.Quartz.Abstract
{
    public interface IRegisterQuartzJob
    {
        IJobDetail GetJobDetailToRun();
        ITrigger GetJobTrigger();
    }
}
