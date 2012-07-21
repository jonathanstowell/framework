using System;
using Common.Logging;
using Quartz;
using ThreeBytes.Caching.Core.Entities.Abstract;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;

namespace ThreeBytes.Caching.KillOutOfDateItems.Jobs
{
    public class KillOutOfDatePagedItemsJob : IJob
    {
        private readonly ILog logger;
        
        private readonly ICacheManager cacheManager;
        private readonly IProvideCacheSettings cacheSettings;
        private readonly ICacheKeyGenerator cacheKeyGenerator;

        public KillOutOfDatePagedItemsJob(IProvideCacheSettings cacheSettings, ICacheManager cacheManager, ICacheKeyGenerator cacheKeyGenerator)
        {
            logger = LogManager.GetLogger(GetType());

            this.cacheSettings = cacheSettings;
            this.cacheManager = cacheManager;
            this.cacheKeyGenerator = cacheKeyGenerator;
        }

        public void Execute(IJobExecutionContext context)
        {
            logger.Info("Executing Kill Out of Date Paged Items Job");

            foreach (var configuration in cacheSettings.CacheItemConfigurations)
            {
                string key = cacheKeyGenerator.PagedPrimaryCacheKey(configuration.Value.ConfigurationType);
                IPagedOrderedContainerCacheItem pagedOrderedContainer = cacheManager.Get<IPagedOrderedContainerCacheItem>(key);

                foreach (var pagedCacheItem in pagedOrderedContainer.Value.Values)
                {
                    foreach (var cacheItem in pagedCacheItem.Value)
                    {
                        if(cacheItem.Value.CacheUntil < DateTime.Now)
                        {
                            pagedCacheItem.Value.Remove(cacheItem.Key);
                            logger.Info(string.Format("Removing Paged cache item: {0} > {1}", key, cacheItem.Key));
                        }
                    }
                }
            }

            logger.Info("Finished Kill Out of Date Paged Items Job");
        }
    }
}
