using System;
using System.Collections.Generic;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Service.Abstract;

namespace ThreeBytes.Core.Service.Concrete
{
    public class GenericService<TEntity> : ReadOnlyGenericService<TEntity>, IGenericService<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        #region Properties
        /// <summary>
        /// The Repository provides the actual database access to CRUD records.
        /// </summary>
        protected new readonly IGenericRepository<TEntity> Repository;
        #endregion

        public GenericService(IGenericRepository<TEntity> repository)
            : base(repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", "Repository cannot be Null");

            Repository = repository;
        }

        public GenericService(IGenericRepository<TEntity> repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
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
                Cache.InvalidateCacheItem(entity);
                Cache.Add(entity);
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
                    Cache.InvalidateCacheItem(item);
                    Cache.Add(item);
                }
            }

            return result;
        }

        public virtual bool Update(TEntity entity)
        {
            Repository.UnitOfWork.BeginTransaction();

            bool result = Repository.Update(entity);

            if (result)
                result = Repository.UnitOfWork.CommitTransaction();
            else
                Repository.UnitOfWork.RollBackTransaction();

            if (result && (CacheEnabled))
                Cache.InvalidateCacheItem(entity);

            return result;
        }

        public virtual bool Update(IEnumerable<TEntity> items)
        {
            Repository.UnitOfWork.BeginTransaction();
            bool result = Repository.Update(items);

            if (result)
                result = Repository.UnitOfWork.CommitTransaction();
            else
                Repository.UnitOfWork.RollBackTransaction();

            if (result && (CacheEnabled) && items != null)
            {
                foreach (var item in items)
                {
                    Cache.InvalidateCacheItem(item);
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
                Cache.InvalidateCacheItem(entity);

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
                    Cache.InvalidateCacheItem(item);
                }
            }

            return result;
        }
    }
}
