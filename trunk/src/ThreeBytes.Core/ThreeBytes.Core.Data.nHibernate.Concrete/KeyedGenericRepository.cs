using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Data.nHibernate.Abstract;

namespace ThreeBytes.Core.Data.nHibernate.Concrete
{
    public class KeyedGenericRepository<TEntity> : GenericRepository<TEntity>, IKeyedGenericRepository<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        public KeyedGenericRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        { }

        public virtual TEntity GetById(Guid id)
        {
            TEntity entity = Session.Get<TEntity>(id);
            return entity;
        }

        public virtual bool Exists(Guid id)
        {
            bool result = Session.QueryOver<TEntity>()
                              .Where(x => x.Id == id)
                              .RowCount() == 1;
            return result;
        }
    }
}
