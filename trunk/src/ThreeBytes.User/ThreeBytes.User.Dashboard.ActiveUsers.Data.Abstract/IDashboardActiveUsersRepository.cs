using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.User.Dashboard.ActiveUsers.Entities;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Data.Abstract
{
    public interface IDashboardActiveUsersRepository : IKeyedGenericRepository<DashboardActiveUsers>
    {
        IPagedResult<DashboardActiveUsers> GetPagedActiveUsers(int take, DateTime? originalRequestDateTime, string applicationName, int page = 1);
    }
}
