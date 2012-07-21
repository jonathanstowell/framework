using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.User.Authentication.UserList.Entities;
using ThreeBytes.User.Authentication.UserList.Entities.Enums;

namespace ThreeBytes.User.Authentication.UserList.Data.Abstract
{
    public interface IAuthenticationUserListUserRepository : IKeyedGenericRepository<AuthenticationUserListUser>
    {
        IList<AuthenticationUserListUser> GetAll(string applicationName);
        IPagedResult<AuthenticationUserListUser> GetAllPaged(int take, DateTime? originalRequestDateTime, string applicationName, AuthenticationUserListUserOrderBy orderBy = AuthenticationUserListUserOrderBy.Username, SortBy sortBy = SortBy.Asc, int page = 1);
        IMostRecentResult<AuthenticationUserListUser> GetLatestSince(DateTime datetime, string applicationName);
        IList<AuthenticationUserListUser> GetMostRecent(int take, string applicationName);
        int Count(string applicationName);
        bool UniqueUsername(string username, string applicationName);
        bool UniqueEmail(string email, string applicationName);
    }
}
