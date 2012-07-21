using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Core.Service.WCF.Abstract;

namespace ThreeBytes.Core.Service.WCF.Concrete
{
    public class KeyedGenericWCFService<TEntity> : GenericWCFService<TEntity>, IKeyedGenericWCFService<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        private readonly IKeyedGenericService<TEntity> keyedGenericService;

        public KeyedGenericWCFService(IKeyedGenericService<TEntity> keyedGenericService) : base(keyedGenericService)
        {
            this.keyedGenericService = keyedGenericService;
        }

        public TEntity GetById(string id)
        {
            return keyedGenericService.GetById(Guid.Parse(id));
        }
    }
}
