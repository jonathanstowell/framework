using System;
using System.Collections.Generic;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Entities.Concrete
{
    [Serializable]
    public abstract class HistoricBusinessObject<TEntity, TId, TIId> : BusinessObject<TEntity, TId> where TEntity : HistoricBusinessObject<TEntity, TId, TIId>, IHistoricBusinessObject<TEntity, TId, TIId>
    {
        public virtual TIId ItemId { get; set; }
        public virtual string Operation { get; set; }
        public virtual IList<TEntity> History { get; set; } 
    }

    [Serializable]
    public abstract class HistoricBusinessObject<TEntity, TIId> : HistoricBusinessObject<TEntity, Guid, TIId> where TEntity : HistoricBusinessObject<TEntity, TIId>, IHistoricBusinessObject<TEntity, TIId>
    {
    }

    [Serializable]
    public abstract class HistoricBusinessObject<TEntity> : HistoricBusinessObject<TEntity, Guid, Guid> where TEntity : HistoricBusinessObject<TEntity>, IHistoricBusinessObject<TEntity>
    {
    }
}
