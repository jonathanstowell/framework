using System;
using System.Collections.Generic;
using System.Linq;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Data.nHibernate.Abstract;

namespace ThreeBytes.Core.Data.nHibernate.Concrete
{
    public class HistoricKeyedGenericRepository<TEntity> : HistoricGenericRepository<TEntity>, IHistoricKeyedGenericRepository<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        public HistoricKeyedGenericRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        { }

        public virtual TEntity GetById(Guid id)
        {
            IList<TEntity> entities = Session.QueryOver<TEntity>().Where(x => x.ItemId == id).List();

            TEntity current = entities.SingleOrDefault(x => x.LastModifiedDateTime == null);
            if (current != null)
            {
                current.History = entities.Where(x => x.LastModifiedDateTime != null).OrderByDescending(x => x.LastModifiedDateTime).ToList();
                return current;
            }

            return null;
        }

        public virtual bool Exists(Guid id)
        {
            bool result = Session.QueryOver<TEntity>().Where(x => x.ItemId == id).RowCount() > 0;
            return result;
        }
    }
}
