using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Data.nHibernate.Abstract;

namespace ThreeBytes.Core.Data.nHibernate.Concrete
{
    public class HistoricGenericRepository<TEntity> : HistoricReadOnlyGenericRepository<TEntity>, IHistoricGenericRepository<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        #region Constructor
        public HistoricGenericRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork)
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

        public virtual bool Add(IEnumerable<TEntity> items)
        {
            foreach (TEntity item in items)
            {
                bool result = Add(item);

                if (!result)
                    return false;
            }
            return true;
        }

        public virtual bool Update(IHistoricalUpdateOperation<TEntity> item)
        {
            item.OldItem.LastModifiedDateTime = DateTime.Now;
            item.OldItem.Operation = item.OperationDescription;
            item.NewItem.Id = Guid.NewGuid();
            item.NewItem.ItemId = item.OldItem.ItemId;
            item.NewItem.CreationDateTime = DateTime.Now;

            try
            {
                Session.Update(item.OldItem);
                Session.Save(item.NewItem);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public virtual bool Update(IEnumerable<IHistoricalUpdateOperation<TEntity>> items)
        {
            foreach (var item in items)
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
                foreach (var hist in entity.History)
                {
                    Session.Delete(hist);
                }

                Session.Delete(entity);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public virtual bool Delete(IEnumerable<TEntity> entities)
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
