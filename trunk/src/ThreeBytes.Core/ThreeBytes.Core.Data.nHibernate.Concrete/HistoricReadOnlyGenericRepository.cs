using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Data.nHibernate.Abstract;

namespace ThreeBytes.Core.Data.nHibernate.Concrete
{
    public class HistoricReadOnlyGenericRepository<TEntity> : RepositoryBase, IHistoricReadOnlyGenericRepository<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        #region Constructors
        public HistoricReadOnlyGenericRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }
        #endregion

        #region Public Methods
        public virtual IList<TEntity> GetAll()
        {
            var entity = Session.QueryOver<TEntity>().Where(x => x.LastModifiedDateTime == null).List();
            return entity;
        }

        public virtual IPagedResult<TEntity> GetAllPaged(int take, DateTime? originalRequestDateTime, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<TEntity> pagedTEntities = Session.QueryOver<TEntity>()
                .Where(x => x.CreationDateTime <= originalRequest && x.LastModifiedDateTime == null)
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<TEntity>()
                .Where(x => x.CreationDateTime <= originalRequest && x.LastModifiedDateTime == null)
                .RowCount();

            return new PagedResult<TEntity>(pagedTEntities, originalRequest, recordsInThisQuery, page, take);
        }

        public virtual IMostRecentResult<TEntity> GetLatestSince(DateTime datetime)
        {
            DateTime now = DateTime.Now;

            IList<TEntity> newestTEntities = Session.QueryOver<TEntity>()
                .Where(x => x.CreationDateTime > datetime && x.LastModifiedDateTime == null)
                .OrderBy(x => x.CreationDateTime).Desc
                .List();

            return new MostRecentResult<TEntity>(newestTEntities, datetime, now);
        }

        public virtual TEntity FindBy(Expression<Func<TEntity, bool>> expression)
        {
            TEntity entity = FilterBy(expression).Where(x => x.LastModifiedDateTime == null).SingleOrDefault();
            return entity;
        }

        public virtual IList<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression)
        {
            IList<TEntity> entities = Session.QueryOver<TEntity>().Where(expression).And(x => x.LastModifiedDateTime == null).List();
            return entities;
        }

        public virtual IPagedResult<TEntity> FilterByPaged(Expression<Func<TEntity, bool>> expression, int take, DateTime? originalRequestDateTime, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<TEntity> pagedTEntities = Session.QueryOver<TEntity>()
                .Where(expression)
                .And(x => x.CreationDateTime < originalRequest)
                .And(x => x.LastModifiedDateTime == null)
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<TEntity>()
                .Where(expression)
                .And(x => x.LastModifiedDateTime == null)
                .RowCount();

            return new PagedResult<TEntity>(pagedTEntities, originalRequest, recordsInThisQuery, page, take);
        }

        public virtual IMostRecentResult<TEntity> FilterByLatestSince(Expression<Func<TEntity, bool>> expression, DateTime datetime)
        {
            DateTime now = DateTime.Now;

            IList<TEntity> newestTEntities = Session.QueryOver<TEntity>()
                .Where(expression)
                .And(x => x.CreationDateTime > datetime)
                .And(x => x.LastModifiedDateTime == null)
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

        public int UniqueCount()
        {
            int result =
                Session.QueryOver<TEntity>()
                .Select(Projections.CountDistinct<TEntity>(x => x.ItemId))
                .RowCount();

            return result;
        }
        #endregion
    }
}
