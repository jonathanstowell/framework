using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Core.Service.WCF.Abstract;

namespace ThreeBytes.Core.Service.WCF.Concrete
{
    public class ReadOnlyGenericWCFService<TEntity> : IReadOnlyGenericWCFService<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        private readonly IReadOnlyGenericService<TEntity> readOnlyGenericService;

        public ReadOnlyGenericWCFService(IReadOnlyGenericService<TEntity> readOnlyGenericService)
        {
            this.readOnlyGenericService = readOnlyGenericService;
        }

        public IList<TEntity> GetAll()
        {
            return readOnlyGenericService.GetAll();
        }

        public IPagedResult<TEntity> GetAllPaged(string take, DateTime? originalRequestDateTime, string page = "1")
        {
            return readOnlyGenericService.GetAllPaged(int.Parse(take), originalRequestDateTime, int.Parse(page));
        }
    }
}
