using System;
using System.Data;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Service.Abstract;

namespace ThreeBytes.Core.Service.Concrete
{
    public class KeyedGenericService<TEntity> : GenericService<TEntity>, IKeyedGenericService<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        #region Properties
        /// <summary>
        /// The Repository provides the actual database access to CRUD records.
        /// </summary>
        protected new readonly IKeyedGenericRepository<TEntity> Repository;
        #endregion

        #region Constructor
        public KeyedGenericService(IKeyedGenericRepository<TEntity> repository)
            : base(repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", "Repository cannot be Null");

            Repository = repository;
        }

        public KeyedGenericService(IKeyedGenericRepository<TEntity> repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
            : base(repository, cache, cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", "Repository cannot be Null");

            Repository = repository;
        }
        #endregion

        public virtual TEntity GetById(Guid id)
        {
            Func<TEntity> getData = () => GetByIdFromDatabase(id);

            if (CacheEnabled)
                return Cache.Fetch(id, getData);

            return getData();
        }

        private TEntity GetByIdFromDatabase(Guid id)
        {
            Repository.UnitOfWork.BeginTransaction(IsolationLevel.ReadUncommitted);
            var ret = Repository.GetById(id);
            Repository.UnitOfWork.CommitTransaction();
            return ret;
        }

        public virtual bool Exists(Guid id)
        {
            return Repository.Exists(id);
        }

        public virtual bool Delete(Guid id)
        {
            TEntity entity = GetById(id);

            bool result = Delete(entity);

            if (result && (CacheEnabled))
                Cache.InvalidateCacheItem(entity);

            return result;
        }
    }
}
