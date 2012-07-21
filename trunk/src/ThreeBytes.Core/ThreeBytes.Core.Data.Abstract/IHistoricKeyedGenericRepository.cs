using System;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Data.Abstract
{
    public interface IHistoricKeyedGenericRepository<TEntity> : IHistoricGenericRepository<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        TEntity GetById(Guid id);
        bool Exists(Guid id);
    }
}
