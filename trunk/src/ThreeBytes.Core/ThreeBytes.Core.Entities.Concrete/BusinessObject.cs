using System;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Entities.Concrete
{
    [Serializable]
    public abstract class BusinessObject<TEntity, TId> where TEntity : BusinessObject<TEntity, TId>, IBusinessObject<TEntity, TId>
    {
        public virtual TId Id { get; set; }

        public virtual DateTime CreationDateTime { get; set; }
        public virtual string CreatedBy { get; set; }

        public virtual DateTime? LastModifiedDateTime { get; set; }
        public virtual string LastModifiedBy { get; set; }

        protected BusinessObject()
        {
            CreationDateTime = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            TEntity other = obj as TEntity;

            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!Equals(default(TId), Id)
              && !Equals(default(TId), other.Id))
                return Equals(Id, other.Id);

            return Equals(other);

        }

        public virtual bool Equals(TEntity other)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return Id == null ? 0 : Id.GetHashCode();
        }
    }

    [Serializable]
    public abstract class BusinessObject<TEntity> : BusinessObject<TEntity, Guid> where TEntity : BusinessObject<TEntity>, IBusinessObject<TEntity>
    {
    }
}
