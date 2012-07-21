using System.Collections.Generic;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Service.Abstract
{
    public interface IHistoricGenericService<TEntity> : IHistoricReadOnlyGenericService<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        bool Create(TEntity entity);
        bool Create(IEnumerable<TEntity> items);
        bool Update(IHistoricalUpdateOperation<TEntity> item);
        bool Update(IEnumerable<IHistoricalUpdateOperation<TEntity>> items);
        bool Delete(TEntity entity);
        bool Delete(IEnumerable<TEntity> entities);
    }
}
