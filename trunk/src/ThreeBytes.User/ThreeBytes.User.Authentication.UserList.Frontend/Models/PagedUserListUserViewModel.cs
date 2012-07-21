using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.User.Authentication.UserList.Entities;

namespace ThreeBytes.User.Authentication.UserList.Frontend.Models
{
    public class PagedUserListUserViewModel
    {
        public IPagedResult<AuthenticationUserListUser> PagedResult { get; set; }
        public IMostRecentResult<AuthenticationUserListUser> MostRecentResult { get; set; }

        public PagedUserListUserViewModel(IPagedResult<AuthenticationUserListUser> pagedResult)
            : this(pagedResult, null)
        {}

        public PagedUserListUserViewModel(IPagedResult<AuthenticationUserListUser> pagedResult, IMostRecentResult<AuthenticationUserListUser> mostRecentResult)
        {
            PagedResult = pagedResult;
            MostRecentResult = mostRecentResult;

            if (mostRecentResult == null)
                MostRecentResult = new MostRecentResult<AuthenticationUserListUser>(new List<AuthenticationUserListUser>(), pagedResult.OriginalRequestDateTime, pagedResult.OriginalRequestDateTime);
        }
    }
}
