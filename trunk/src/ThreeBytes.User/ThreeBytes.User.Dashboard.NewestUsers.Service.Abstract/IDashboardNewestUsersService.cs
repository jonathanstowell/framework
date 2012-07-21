using System;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Dashboard.NewestUsers.Entities;

namespace ThreeBytes.User.Dashboard.NewestUsers.Service.Abstract
{
    public interface IDashboardNewestUsersService : IKeyedGenericService<DashboardNewestUsers>
    {
        IPagedResult<DashboardNewestUsers> GetPagedNewestUsers(int take, DateTime? originalRequestDateTime, string applicationName, int page = 1);
    }
}
