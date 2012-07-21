using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Service.Abstract
{
    public interface IHistoricReadOnlyGenericService<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        IList<TEntity> GetAll();
        IPagedResult<TEntity> GetAllPaged(int take, DateTime? originalRequestDateTime, int page = 1);
        IMostRecentResult<TEntity> GetLatestSince(DateTime datetime);
        TEntity FindBy(Expression<Func<TEntity, bool>> expression);
        IList<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
        IPagedResult<TEntity> FilterByPaged(Expression<Func<TEntity, bool>> expression, int take, DateTime? originalRequestDateTime, int page = 1);
        IMostRecentResult<TEntity> FilterByLatestSince(Expression<Func<TEntity, bool>> expression, DateTime datetime);
        IList<TEntity> GetMostRecent(int take);
        int Count();
        bool HasRecords();
        int UniqueCount();
        bool HasUniqueRecords();
    }
}
