using System;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Service.Abstract
{
    public interface IKeyedGenericService<TEntity> : IGenericService<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        TEntity GetById(Guid id);
        bool Exists(Guid id);
    }
}
