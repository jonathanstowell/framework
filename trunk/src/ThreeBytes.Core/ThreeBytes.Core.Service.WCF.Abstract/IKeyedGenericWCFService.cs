using System.ServiceModel;
using System.ServiceModel.Web;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Service.WCF.Abstract
{
    public interface IKeyedGenericWCFService<TEntity> : IGenericWCFService<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        [WebGet(UriTemplate = "GetById/{id}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        TEntity GetById(string id);
    }
}
