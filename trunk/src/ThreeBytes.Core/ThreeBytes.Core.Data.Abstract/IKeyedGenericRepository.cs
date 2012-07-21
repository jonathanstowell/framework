using System;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Data.Abstract
{
    public interface IKeyedGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        TEntity GetById(Guid id);
        bool Exists(Guid id);
    }
}
