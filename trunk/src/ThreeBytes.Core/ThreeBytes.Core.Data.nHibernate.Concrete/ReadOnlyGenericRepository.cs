using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Data.nHibernate.Abstract;

namespace ThreeBytes.Core.Data.nHibernate.Concrete
{
    public class ReadOnlyGenericRepository<TEntity> : RepositoryBase, IReadOnlyGenericRepository<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        #region Constructors
        public ReadOnlyGenericRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }
        #endregion

        #region Public Methods
        public virtual IList<TEntity> GetAll()
        {
            var entity = Session.QueryOver<TEntity>().List();
            return entity;
        }

        public virtual IPagedResult<TEntity> GetAllPaged(int take, DateTime? originalRequestDateTime, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<TEntity> pagedTEntities = Session.QueryOver<TEntity>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<TEntity>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .RowCount();

            return new PagedResult<TEntity>(pagedTEntities, originalRequest, recordsInThisQuery, page, take);
        }

        public virtual IMostRecentResult<TEntity> GetLatestSince(DateTime datetime)
        {
            DateTime now = DateTime.Now;

            IList<TEntity> newestTEntities = Session.QueryOver<TEntity>()
                .Where(x => x.CreationDateTime > datetime)
                .OrderBy(x => x.CreationDateTime).Desc
                .List();

            return new MostRecentResult<TEntity>(newestTEntities, datetime, now);
        }

        public virtual TEntity FindBy(Expression<Func<TEntity, bool>> expression)
        {
            TEntity entity = FilterBy(expression).SingleOrDefault();
            return entity;
        }

        public virtual IList<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression)
        {
            IList<TEntity> entities = Session.QueryOver<TEntity>().Where(expression).List();
            return entities;
        }

        public virtual IPagedResult<TEntity> FilterByPaged(Expression<Func<TEntity, bool>> expression, int take, DateTime? originalRequestDateTime, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<TEntity> pagedTEntities = Session.QueryOver<TEntity>()
                .Where(expression)
                .And(x => x.CreationDateTime < originalRequest)
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<TEntity>()
                .Where(expression)
                .RowCount();

            return new PagedResult<TEntity>(pagedTEntities, originalRequest, recordsInThisQuery, page, take);
        }

        public virtual IMostRecentResult<TEntity> FilterByLatestSince(Expression<Func<TEntity, bool>> expression, DateTime datetime)
        {
            DateTime now = DateTime.Now;

            IList<TEntity> newestTEntities = Session.QueryOver<TEntity>()
                .Where(expression)
                .And(x => x.CreationDateTime > datetime)
                .List();

            return new MostRecentResult<TEntity>(newestTEntities, datetime, now);
        }

        public IList<TEntity> GetMostRecent(int take)
        {
            IList<TEntity> result = Session.QueryOver<TEntity>()
                .OrderBy(x => x.CreationDateTime).Desc
                .Take(take)
                .List();

            return result;
        }

        public int Count()
        {
            int result = Session.QueryOver<TEntity>()
                .RowCount();

            return result;
        }
        #endregion
    }
}
