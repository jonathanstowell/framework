using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Data.Entities.Concrete
{
    public class HistoricalUpdateOperation<TEntity> : IHistoricalUpdateOperation<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        public TEntity OldItem { get; set; }
        public TEntity NewItem { get; set; }
        public string OperationDescription { get; set; }
    }
}
