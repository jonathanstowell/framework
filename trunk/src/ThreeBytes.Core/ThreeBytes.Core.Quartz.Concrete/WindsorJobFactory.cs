using System;
using Microsoft.Practices.ServiceLocation;
using Quartz;
using Quartz.Spi;

namespace ThreeBytes.Core.Quartz.Concrete
{
    public class WindsorJobFactory : IJobFactory
    {
        readonly IServiceLocator locator;

        public bool ResolveByJobName { get; set; }

        public WindsorJobFactory(IServiceLocator locator)
        {
            this.locator = locator;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                IJobDetail jobDetail = bundle.JobDetail;
                Type jobType = jobDetail.JobType;
                return (IJob)locator.GetInstance(jobType);
            }
            catch (Exception e)
            {
                throw new SchedulerException("Problem instantiating class", e);
            }
        }
    }
}
