using System.Collections.Generic;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Service.Abstract
{
    public interface IGenericService<TEntity> : IReadOnlyGenericService<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        bool Create(TEntity entity);
        bool Create(IEnumerable<TEntity> items);
        bool Update(TEntity entity);
        bool Update(IEnumerable<TEntity> items);
        bool Delete(TEntity entity);
        bool Delete(IEnumerable<TEntity> entities);
    }
}
