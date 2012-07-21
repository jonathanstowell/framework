using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.User.Role.List.Entities;

namespace ThreeBytes.User.Role.List.Frontend.Models
{
    public class PagedRoleListRoleViewModel
    {
        public IPagedResult<RoleListRole> PagedResult { get; set; }
        public IMostRecentResult<RoleListRole> MostRecentResult { get; set; }

        public PagedRoleListRoleViewModel(IPagedResult<RoleListRole> pagedResult)
            : this(pagedResult, null)
        {}

        public PagedRoleListRoleViewModel(IPagedResult<RoleListRole> pagedResult, IMostRecentResult<RoleListRole> mostRecentResult)
        {
            PagedResult = pagedResult;
            MostRecentResult = mostRecentResult;

            if (mostRecentResult == null)
                MostRecentResult = new MostRecentResult<RoleListRole>(new List<RoleListRole>(), pagedResult.OriginalRequestDateTime, pagedResult.OriginalRequestDateTime);
        }
    }
}
