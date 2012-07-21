using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Caching.Configuration.Abstract;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Service.Abstract;

namespace ThreeBytes.Core.Service.Concrete
{
    public class HistoricReadOnlyGenericService<TEntity> : IHistoricReadOnlyGenericService<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        #region Properties
        protected readonly IHistoricReadOnlyGenericRepository<TEntity> Repository;
        protected readonly ICacheManager Cache;
        protected readonly IProvideCacheSettings CacheSettings;

        protected bool CacheEnabled { get { return Cache != null && CacheSettings.Enabled(); } }
        #endregion

        #region Constructor
        public HistoricReadOnlyGenericService(IHistoricReadOnlyGenericRepository<TEntity> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", "Repository cannot be Null");

            Repository = repository;
        }

        public HistoricReadOnlyGenericService(IHistoricReadOnlyGenericRepository<TEntity> repository, ICacheManager cache, IProvideCacheSettings cacheSettings)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", "Repository cannot be Null");

            if (cache == null)
                throw new ArgumentNullException("cache");

            if (repository == null)
                throw new ArgumentNullException("cacheSettings");

            Repository = repository;
            Cache = cache;
            CacheSettings = cacheSettings;
        }
        #endregion

        #region IService Members
        public virtual IList<TEntity> GetAll()
        {
            Func<IList<TEntity>> getData = GetAllFromDatabase;

            if (CacheEnabled)
                return Cache.Fetch(getData);

            return getData();
        }

        private IList<TEntity> GetAllFromDatabase()
        {
            Repository.UnitOfWork.BeginTransaction(IsolationLevel.ReadUncommitted);
            var ret = Repository.GetAll();
            Repository.UnitOfWork.CommitTransaction();
            return ret;
        }

        public IPagedResult<TEntity> GetAllPaged(int take, DateTime? originalRequestDateTime, int page = 1)
        {
            Func<IPagedResult<TEntity>> getData = () => GetAllPagedFromDatabase(take, originalRequestDateTime, page);

            if (CacheEnabled)
                return Cache.Fetch(page, originalRequestDateTime, getData);

            return getData();
        }

        private IPagedResult<TEntity> GetAllPagedFromDatabase(int take, DateTime? originalRequestDateTime, int page = 1)
        {
            Repository.UnitOfWork.BeginTransaction(IsolationLevel.ReadUncommitted);
            var ret = Repository.GetAllPaged(take, originalRequestDateTime, page);
            Repository.UnitOfWork.CommitTransaction();
            return ret;
        }

        public virtual IMostRecentResult<TEntity> GetLatestSince(DateTime datetime)
        {
            Func<IMostRecentResult<TEntity>> getData = () => GetLatestSinceFromDatabase(datetime);

            if (CacheEnabled)
                return Cache.Fetch(datetime, getData);

            return getData();
        }

        private IMostRecentResult<TEntity> GetLatestSinceFromDatabase(DateTime datetime)
        {
            Repository.UnitOfWork.BeginTransaction(IsolationLevel.ReadUncommitted);
            var ret = Repository.GetLatestSince(datetime);
            Repository.UnitOfWork.CommitTransaction();
            return ret;
        }

        public virtual TEntity FindBy(Expression<Func<TEntity, bool>> expression)
        {
            return Repository.FindBy(expression);
        }

        public virtual IList<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression)
        {
            return Repository.FilterBy(expression);
        }

        public IPagedResult<TEntity> FilterByPaged(Expression<Func<TEntity, bool>> expression, int take, DateTime? originalRequestDateTime, int page = 1)
        {
            return Repository.FilterByPaged(expression, take, originalRequestDateTime, page);
        }

        public IMostRecentResult<TEntity> FilterByLatestSince(Expression<Func<TEntity, bool>> expression, DateTime datetime)
        {
            return Repository.FilterByLatestSince(expression, datetime);
        }

        public IList<TEntity> GetMostRecent(int take)
        {
            return Repository.GetMostRecent(take);
        }

        public int Count()
        {
            return Repository.Count();
        }

        public bool HasRecords()
        {
            return Count() > 0;
        }

        public int UniqueCount()
        {
            return Repository.UniqueCount();
        }

        public bool HasUniqueRecords()
        {
            return UniqueCount() > 0;
        }
        #endregion
    }
}
