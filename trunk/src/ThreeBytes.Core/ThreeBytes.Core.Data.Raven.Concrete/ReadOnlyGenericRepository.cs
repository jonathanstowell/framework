using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.Raven.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Data.Raven.Concrete
{
    public class ReadOnlyGenericRepository<TEntity> : RepositoryBase, IReadOnlyGenericRepository<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        #region Constructors
        public ReadOnlyGenericRepository(IRavenDatabaseFactory databaseFactory, IUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }
        #endregion

        #region Public Methods
        public virtual IList<TEntity> GetAll()
        {
            var entity = Session.Query<TEntity>().ToList();
            return entity;
        }

        public virtual IPagedResult<TEntity> GetAllPaged(int take, DateTime? originalRequestDateTime, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<TEntity> pagedTEntities = Session.Query<TEntity>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .Skip(firstResult)
                .Take(take)
                .ToList();

            int recordsInThisQuery = Session.Query<TEntity>().Count(x => x.CreationDateTime <= originalRequest);

            return new PagedResult<TEntity>(pagedTEntities, originalRequest, recordsInThisQuery, page, take);
        }

        public virtual IMostRecentResult<TEntity> GetLatestSince(DateTime datetime)
        {
            DateTime now = DateTime.Now;

            IList<TEntity> newestTEntities = Session.Query<TEntity>()
                .Where(x => x.CreationDateTime > datetime)
                .OrderByDescending(x => x.CreationDateTime)
                .ToList();

            return new MostRecentResult<TEntity>(newestTEntities, datetime, now);
        }

        public virtual TEntity FindBy(Expression<Func<TEntity, bool>> expression)
        {
            TEntity entity = FilterBy(expression).SingleOrDefault();
            return entity;
        }

        public virtual IList<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression)
        {
            IList<TEntity> entities = Session.Query<TEntity>().Where(expression).ToList();
            return entities;
        }

        public virtual IPagedResult<TEntity> FilterByPaged(Expression<Func<TEntity, bool>> expression, int take, DateTime? originalRequestDateTime, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<TEntity> pagedTEntities = Session.Query<TEntity>()
                .Where(expression)
                .Where(x => x.CreationDateTime < originalRequest)
                .Skip(firstResult)
                .Take(take)
                .ToList();

            int recordsInThisQuery = Session.Query<TEntity>()
                .Where(expression)
                .Count();

            return new PagedResult<TEntity>(pagedTEntities, originalRequest, recordsInThisQuery, page, take);
        }

        public virtual IMostRecentResult<TEntity> FilterByLatestSince(Expression<Func<TEntity, bool>> expression, DateTime datetime)
        {
            DateTime now = DateTime.Now;

            IList<TEntity> newestTEntities = Session.Query<TEntity>()
                .Where(expression)
                .Where(x => x.CreationDateTime > datetime)
                .ToList();

            return new MostRecentResult<TEntity>(newestTEntities, datetime, now);
        }

        public IList<TEntity> GetMostRecent(int take)
        {
            IList<TEntity> result = Session.Query<TEntity>()
                .OrderByDescending(x => x.CreationDateTime)
                .Take(take)
                .ToList();

            return result;
        }

        public int Count()
        {
            int result = Session.Query<TEntity>().Count();
            return result;
        }
        #endregion
    }
}
