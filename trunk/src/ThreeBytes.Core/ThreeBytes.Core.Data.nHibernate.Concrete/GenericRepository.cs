using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Data.nHibernate.Abstract;

namespace ThreeBytes.Core.Data.nHibernate.Concrete
{
    public class GenericRepository<TEntity> : ReadOnlyGenericRepository<TEntity>, IGenericRepository<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        #region Constructor
        public GenericRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }
        #endregion

        #region Public Methods
        public virtual bool Add(TEntity entity)
        {
            entity.CreationDateTime = DateTime.Now;

            try
            {
                Session.Save(entity);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public virtual bool Add(System.Collections.Generic.IEnumerable<TEntity> items)
        {
            foreach (TEntity item in items)
            {
                bool result = Add(item);

                if (!result)
                    return false;
            }
            return true;
        }

        public virtual bool Update(TEntity entity)
        {
            entity.LastModifiedDateTime = DateTime.Now;

            try
            {
                Session.Update(entity);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public virtual bool Update(System.Collections.Generic.IEnumerable<TEntity> items)
        {
            foreach (TEntity item in items)
            {
                bool result = Update(item);

                if (!result)
                    return false;
            }
            return true;
        }

        public virtual bool Delete(TEntity entity)
        {
            try
            {
                Session.Delete(entity);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public virtual bool Delete(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                bool result = Delete(entity);

                if (!result)
                    return false;
            }
            return true;
        }

        public bool FlushChanges()
        {
            try
            {
                Session.Flush();
            }
            catch (Exception)
            {
                Session.Clear();
                return false;
            }

            return true;
        }
        #endregion
    }
}
