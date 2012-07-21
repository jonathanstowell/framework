using System;

namespace ThreeBytes.Core.Entities.Abstract
{
    public interface IBusinessObject<TEntity, TId> where TEntity : class, IBusinessObject<TEntity, TId>
    {
        TId Id { get; set; }
        DateTime CreationDateTime { get; set; }
        string CreatedBy { get; set; }
        DateTime? LastModifiedDateTime { get; set; }
        string LastModifiedBy { get; set; }
    }

    public interface IBusinessObject<TEntity> : IBusinessObject<TEntity, Guid> where TEntity : class, IBusinessObject<TEntity>
    {
    }
}
