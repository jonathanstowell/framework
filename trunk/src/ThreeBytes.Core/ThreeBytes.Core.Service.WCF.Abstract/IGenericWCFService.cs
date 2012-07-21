using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Service.WCF.Abstract
{
    public interface IGenericWCFService<TEntity> : IReadOnlyGenericWCFService<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        [WebInvoke(Method = "POST", UriTemplate = "Create", RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool Create(TEntity entity);

        [WebInvoke(Method = "POST", UriTemplate = "Create", RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool Create(IEnumerable<TEntity> items);

        [WebInvoke(Method = "POST", UriTemplate = "Update", RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool Update(TEntity entity);

        [WebInvoke(Method = "POST", UriTemplate = "Update", RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool Update(IEnumerable<TEntity> items);

        [WebInvoke(Method = "POST", UriTemplate = "Delete", RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool Delete(TEntity entity);

        [WebInvoke(Method = "POST", UriTemplate = "Delete", RequestFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool Delete(IEnumerable<TEntity> entities);
    }
}
