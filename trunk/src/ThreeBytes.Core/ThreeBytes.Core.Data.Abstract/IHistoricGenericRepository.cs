using System.Collections.Generic;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Data.Abstract
{
    public interface IHistoricGenericRepository<TEntity> : IHistoricReadOnlyGenericRepository<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        bool Add(TEntity entity);
        bool Add(IEnumerable<TEntity> items);
        bool Update(IHistoricalUpdateOperation<TEntity> item);
        bool Update(IEnumerable<IHistoricalUpdateOperation<TEntity>> items);
        bool Delete(TEntity entity);
        bool Delete(IEnumerable<TEntity> entities);
        bool FlushChanges();
    }
}
