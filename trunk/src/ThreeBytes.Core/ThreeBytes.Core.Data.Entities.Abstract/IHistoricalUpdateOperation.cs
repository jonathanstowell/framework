using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Data.Entities.Abstract
{
    public interface IHistoricalUpdateOperation<TEntity> where TEntity : class, IHistoricBusinessObject<TEntity>
    {
        TEntity OldItem { get; set; }
        TEntity NewItem { get; set; }
        string OperationDescription { get; set; }
    }
}
