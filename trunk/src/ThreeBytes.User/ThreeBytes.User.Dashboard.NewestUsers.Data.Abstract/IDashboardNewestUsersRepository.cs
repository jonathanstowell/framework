using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.User.Dashboard.NewestUsers.Entities;

namespace ThreeBytes.User.Dashboard.NewestUsers.Data.Abstract
{
    public interface IDashboardNewestUsersRepository : IKeyedGenericRepository<DashboardNewestUsers>
    {
        IPagedResult<DashboardNewestUsers> GetPagedNewestUsers(int take, DateTime? originalRequestDateTime, string applicationName, int page = 1);
    }
}
