using System.Collections.Generic;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Data.Abstract
{
    public interface IGenericRepository<TEntity> : IReadOnlyGenericRepository<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        bool Add(TEntity entity);
        bool Add(IEnumerable<TEntity> items);
        bool Update(TEntity entity);
        bool Update(IEnumerable<TEntity> items);
        bool Delete(TEntity entity);
        bool Delete(IEnumerable<TEntity> entities);
    }
}
