using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.NewestUsers.Data.Abstract;
using ThreeBytes.User.Dashboard.NewestUsers.Data.Abstract.Infrastructure;
using ThreeBytes.User.Dashboard.NewestUsers.Entities;

namespace ThreeBytes.User.Dashboard.NewestUsers.Data.Concrete
{
    public class DashboardNewestUsersRepository : KeyedGenericRepository<DashboardNewestUsers>, IDashboardNewestUsersRepository
    {
        public DashboardNewestUsersRepository(IDashboardNewestUsersDatabaseFactory databaseFactory, IDashboardNewestUsersUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public IPagedResult<DashboardNewestUsers> GetPagedNewestUsers(int take, DateTime? originalRequestDateTime, string applicationName, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<DashboardNewestUsers> pagedDailyLogins = Session.QueryOver<DashboardNewestUsers>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .OrderBy(x => x.RegistrationDateTime).Desc
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<DashboardNewestUsers>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .RowCount();

            return new PagedResult<DashboardNewestUsers>(pagedDailyLogins, originalRequest, recordsInThisQuery, page, take);
        }
    }
}
