using System;
using System.Collections.Generic;

namespace ThreeBytes.Core.Entities.Abstract
{
    public interface IHistoricBusinessObject<TEntity, TId, TIId> : IBusinessObject<TEntity, TId> where TEntity : class, IHistoricBusinessObject<TEntity, TId, TIId>
    {
        TIId ItemId { get; set; }
        string Operation { get; set; }
        IList<TEntity> History { get; set; } 
    }

    public interface IHistoricBusinessObject<TEntity, TIId> : IHistoricBusinessObject<TEntity, Guid, TIId> where TEntity : class, IHistoricBusinessObject<TEntity, TIId>
    {
    }

    public interface IHistoricBusinessObject<TEntity> : IHistoricBusinessObject<TEntity, Guid, Guid> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
    }
}
