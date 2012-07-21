using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Entities.Abstract;

namespace ThreeBytes.Core.Service.WCF.Abstract
{
    public interface IReadOnlyGenericWCFService<TEntity> where TEntity : class, IBusinessObject<TEntity>
    {
        [WebGet(UriTemplate = "GetAll", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IList<TEntity> GetAll();

        [WebGet(UriTemplate = "GetAllPaged", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        IPagedResult<TEntity> GetAllPaged(string take, DateTime? originalRequestDateTime, string page = "1");
    }
}
