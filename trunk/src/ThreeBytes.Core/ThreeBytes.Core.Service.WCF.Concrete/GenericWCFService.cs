using System.Collections.Generic;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Core.Service.WCF.Abstract;

namespace ThreeBytes.Core.Service.WCF.Concrete
{
    public class GenericWCFService<TEntity> : ReadOnlyGenericWCFService<TEntity>, IGenericWCFService<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        private readonly IGenericService<TEntity> genericService;

        public GenericWCFService(IGenericService<TEntity> genericService) : base(genericService)
        {
            this.genericService = genericService;
        }

        public bool Create(TEntity entity)
        {
            return genericService.Create(entity);
        }

        public bool Create(IEnumerable<TEntity> items)
        {
            return genericService.Create(items);
        }

        public bool Update(TEntity entity)
        {
            return genericService.Update(entity);
        }

        public bool Update(IEnumerable<TEntity> items)
        {
            return genericService.Update(items);
        }

        public bool Delete(TEntity entity)
        {
            return genericService.Delete(entity);
        }

        public bool Delete(IEnumerable<TEntity> entities)
        {
            return genericService.Delete(entities);
        }
    }
}
