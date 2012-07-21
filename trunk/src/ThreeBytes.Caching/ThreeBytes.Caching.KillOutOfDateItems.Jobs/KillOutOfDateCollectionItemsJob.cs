using System;
using Common.Logging;
using Quartz;
using ThreeBytes.Caching.Core.Entities.Abstract;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;

namespace ThreeBytes.Caching.KillOutOfDateItems.Jobs
{
    public class KillOutOfDateCollectionItemsJob : IJob
    {
        private readonly ILog logger;

        private readonly ICacheManager cacheManager;
        private readonly IProvideCacheSettings cacheSettings;
        private readonly ICacheKeyGenerator cacheKeyGenerator;

        public KillOutOfDateCollectionItemsJob(IProvideCacheSettings cacheSettings, ICacheManager cacheManager, ICacheKeyGenerator cacheKeyGenerator)
        {
            logger = LogManager.GetLogger(GetType());

            this.cacheSettings = cacheSettings;
            this.cacheManager = cacheManager;
            this.cacheKeyGenerator = cacheKeyGenerator;
        }

        public void Execute(IJobExecutionContext context)
        {
            logger.Info("Executing Kill Out of Date Collection Items Job");

            foreach (var configuration in cacheSettings.CacheItemConfigurations)
            {
                string key = cacheKeyGenerator.CollectionPrimaryCacheKey(configuration.Value.ConfigurationType);
                ICollectionOrderedContainerCacheItem orderedCollectionsContainer = cacheManager.Get<ICollectionOrderedContainerCacheItem>(key);

                foreach (var collectionItem in orderedCollectionsContainer.Value)
                {
                    if (collectionItem.Value.CacheUntil < DateTime.Now)
                    {
                        orderedCollectionsContainer.Value.Remove(collectionItem.Key);
                        logger.Info(string.Format("Removing Collection cache item: {0} > {1}", key, collectionItem.Key));
                    }
                }
            }

            logger.Info("Finished Kill Out of Date Collection Items Job");
        }
    }
}