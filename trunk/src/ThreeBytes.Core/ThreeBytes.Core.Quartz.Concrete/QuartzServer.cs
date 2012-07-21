using System.Threading;
using Castle.Windsor;
using Common.Logging;
using Quartz;
using Quartz.Spi;
using ThreeBytes.Core.Quartz.Abstract;

namespace ThreeBytes.Core.Quartz.Concrete
{
    public class QuartzServer : IQuartzServer
    {
        private readonly ILog logger;

        private readonly IWindsorContainer container;

        private ISchedulerFactory schedulerFactory;
        private IScheduler scheduler;
        private IJobFactory jobFactory;

        public QuartzServer(IWindsorContainer container)
        {
            this.logger = LogManager.GetLogger(GetType());
            this.container = container;

            foreach (var registration in container.ResolveAll<IRegisterQuartzJob>())
            {
                Scheduler.ScheduleJob(registration.GetJobDetailToRun(), registration.GetJobTrigger());
            }
        }

        protected virtual ISchedulerFactory SchedulerFactory
        {
            get { return schedulerFactory ?? (schedulerFactory = container.Resolve<ISchedulerFactory>()); }
        }

        protected virtual IScheduler Scheduler
        {
            get { return scheduler ?? (scheduler = GetScheduler()); }
        }

        protected virtual IJobFactory JobFactory
        {
            get { return jobFactory ?? (jobFactory = container.Resolve<IJobFactory>()); }
        }

        private IScheduler GetScheduler()
        {
            IScheduler scheduler = SchedulerFactory.GetScheduler();
            scheduler.JobFactory = JobFactory;
            return scheduler;
        }

        public virtual void Start()
        {
            scheduler.Start();

            try
            {
                Thread.Sleep(3000);
            }
            catch (ThreadInterruptedException)
            {
            }

            logger.Info("Scheduler started successfully");
        }

        public virtual void Stop()
        {
            scheduler.Shutdown(true);
            logger.Info("Scheduler shutdown complete");
        }

        public virtual void Dispose()
        {
            // no-op for now
        }

        public virtual void Pause()
        {
            scheduler.PauseAll();
        }

        public void Resume()
        {
            scheduler.ResumeAll();
        }
    }
}
