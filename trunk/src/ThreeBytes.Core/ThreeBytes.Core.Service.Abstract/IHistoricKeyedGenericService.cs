using System;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Service.Abstract
{
    public interface IHistoricKeyedGenericService<TEntity> : IHistoricGenericService<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        TEntity GetById(Guid id);
        bool Exists(Guid id);
    }
}
