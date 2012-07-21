using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Service.Abstract;

namespace ThreeBytes.Core.Service.Concrete
{
    public class HistoricGenericService<TEntity> : HistoricReadOnlyGenericService<TEntity>, IHistoricGenericService<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        #region Properties
        /// <summary>
        /// The Repository provides the actual database access to CRUD records.
        /// </summary>
        protected new readonly IHistoricGenericRepository<TEntity> Repository;
        #endregion

        public HistoricGenericService(IHistoricGenericRepository<TEntity> repository)
            : base(repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", "Repository cannot be Null");

            Repository = repository;
        }

        public HistoricGenericService(IHistoricGenericRepository<TEntity> repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", "Repository cannot be Null");

            Repository = repository;
        }

        public virtual bool Create(TEntity entity)
        {
            Repository.UnitOfWork.BeginTransaction();

            bool result = Repository.Add(entity);

            if (result)
                result = Repository.UnitOfWork.CommitTransaction();
            else
                Repository.UnitOfWork.RollBackTransaction();

            if (result && (CacheEnabled))
            {
                Cache.InvalidateHistoricCacheItem(entity);
                Cache.AddHistoric(entity);
            }

            return result;
        }

        public virtual bool Create(IEnumerable<TEntity> items)
        {
            Repository.UnitOfWork.BeginTransaction();

            bool result = Repository.Add(items);

            if (result)
                result = Repository.UnitOfWork.CommitTransaction();
            else
                Repository.UnitOfWork.RollBackTransaction();

            if (result && (CacheEnabled))
            {
                foreach (var item in items)
                {
                    Cache.InvalidateHistoricCacheItem(item);
                    Cache.AddHistoric(item);
                }
            }

            return result;
        }

        public virtual bool Update(IHistoricalUpdateOperation<TEntity> item)
        {
            Repository.UnitOfWork.BeginTransaction();

            bool result = Repository.Update(item);

            if (result)
                result = Repository.UnitOfWork.CommitTransaction();
            else
                Repository.UnitOfWork.RollBackTransaction();

            if (result && (CacheEnabled))
                Cache.InvalidateHistoricCacheItem(item.NewItem);

            return result;
        }

        public virtual bool Update(IEnumerable<IHistoricalUpdateOperation<TEntity>> items)
        {
            Repository.UnitOfWork.BeginTransaction();

            bool result = Repository.Update(items);

            if (result)
                result = Repository.UnitOfWork.CommitTransaction();
            else
                Repository.UnitOfWork.RollBackTransaction();

            if (result && (CacheEnabled))
            {
                foreach (var item in items)
                {
                    Cache.InvalidateHistoricCacheItem(item.NewItem);
                }
            }

            return result;
        }

        public virtual bool Delete(TEntity entity)
        {
            Repository.UnitOfWork.BeginTransaction();

            bool result = Repository.Delete(entity);

            if (result)
                result = Repository.UnitOfWork.CommitTransaction();
            else
                Repository.UnitOfWork.RollBackTransaction();

            if (result && (CacheEnabled))
                Cache.InvalidateHistoricCacheItem(entity);

            return result;
        }

        public virtual bool Delete(IEnumerable<TEntity> items)
        {
            Repository.UnitOfWork.BeginTransaction();

            bool result = Repository.Delete(items);

            if (result)
                result = Repository.UnitOfWork.CommitTransaction();
            else
                Repository.UnitOfWork.RollBackTransaction();

            if (result && (CacheEnabled))
            {
                foreach (var item in items)
                {
                    Cache.InvalidateHistoricCacheItem(item);
                }
            }

            return result;
        }
    }
}
