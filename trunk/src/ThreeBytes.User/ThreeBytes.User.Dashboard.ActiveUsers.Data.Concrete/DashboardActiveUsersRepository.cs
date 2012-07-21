using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.ActiveUsers.Data.Abstract;
using ThreeBytes.User.Dashboard.ActiveUsers.Data.Abstract.Infrastructure;
using ThreeBytes.User.Dashboard.ActiveUsers.Entities;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Data.Concrete
{
    public class DashboardActiveUsersRepository : KeyedGenericRepository<DashboardActiveUsers>, IDashboardActiveUsersRepository
    {
        public DashboardActiveUsersRepository(IDashboardActiveUsersDatabaseFactory databaseFactory, IDashboardActiveUsersUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public IPagedResult<DashboardActiveUsers> GetPagedActiveUsers(int take, DateTime? originalRequestDateTime, string applicationName, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<DashboardActiveUsers> pagedDailyLogins = Session.QueryOver<DashboardActiveUsers>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .OrderBy(x => x.Logins).Desc
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<DashboardActiveUsers>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .RowCount();

            return new PagedResult<DashboardActiveUsers>(pagedDailyLogins, originalRequest, recordsInThisQuery, page, take);
        }
    }
}
