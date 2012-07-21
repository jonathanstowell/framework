using System;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Dashboard.ActiveUsers.Entities;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Service.Abstract
{
    public interface IDashboardActiveUsersService : IKeyedGenericService<DashboardActiveUsers>
    {
        IPagedResult<DashboardActiveUsers> GetPagedActiveUsers(int take, DateTime? originalRequestDateTime, string applicationName, int page = 1);
    }
}
