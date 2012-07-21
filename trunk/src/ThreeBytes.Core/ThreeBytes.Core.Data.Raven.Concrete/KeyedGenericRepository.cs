using System;
using Raven.Client.Linq;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.Raven.Abstract;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Data.Raven.Concrete
{
    public class KeyedGenericRepository<TEntity> : GenericRepository<TEntity>, IKeyedGenericRepository<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        public KeyedGenericRepository(IRavenDatabaseFactory databaseFactory, IUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        { }

        public virtual TEntity GetById(Guid id)
        {
            TEntity entity = Session.Load<TEntity>(id);
            return entity;
        }

        public virtual bool Exists(Guid id)
        {
            bool result = Session.Query<TEntity>().Where(x => x.Id == id) != null;                       
            return result;
        }
    }
}
