using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.LoginStatistics.Data.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Data.Abstract.Infrastructure;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Entities;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Data.Concrete
{
    public class DashboardLoginStatisticsDailyRepository : KeyedGenericRepository<DashboardLoginStatisticsDaily>, IDashboardDailyLoginRepository
    {
        public DashboardLoginStatisticsDailyRepository(IDashboardLoginStatisticsDailyDatabaseFactory databaseFactory, IDashboardLoginStatisticsDailyUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public int GetTodaysLoginCount(string applicationName)
        {
            return Session.QueryOver<DashboardLoginStatisticsDaily>()
                .Where(x => x.LoginDate == DateTime.Today)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();
        }

        public int[] GetLastThirtyDaysLoginCounts(string applicationName)
        {
            var counts = Session.QueryOver<DashboardLoginStatisticsDaily>()
                .Select(
                    Projections.Group<DashboardLoginStatisticsDaily>(x => x.LoginDate),
                    Projections.Count<DashboardLoginStatisticsDaily>(x => x.LoginDate))
                .Where(x => x.LoginDate >= DateTime.Today.AddDays(-30))
                .And(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.LoginDate).Desc
                .Take(30)
                .List<object[]>();

            var ret = new List<int>();

            if (counts.Count == 30)
                return counts.Select(x => (int) x[1]).ToArray();

            for (int i = 0; i < (30 - counts.Count); i++)
            {
                ret.Add(0);
            }

            ret.AddRange(counts.Select(x => (int)x[1]).ToList());

            return ret.ToArray();
        }

        public bool HasUserHasLoggedInToday(Guid userId, string applicationName, DateTime date)
        {
            return Session.QueryOver<DashboardLoginStatisticsDaily>()
                       .Where(x => x.UserId == userId)
                       .And(x => x.ApplicationName == applicationName)
                       .And(x => x.LoginDate == date)
                       .RowCount() > 0;
        }

        public IPagedResult<DashboardLoginStatisticsDaily> GetPagedDailyLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, DateTime day, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<DashboardLoginStatisticsDaily> pagedDailyLogins = Session.QueryOver<DashboardLoginStatisticsDaily>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.LoginDate == day)
                .OrderBy(x => x.Username).Asc
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<DashboardLoginStatisticsDaily>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.LoginDate == day)
                .RowCount();

            return new PagedResult<DashboardLoginStatisticsDaily>(pagedDailyLogins, originalRequest, recordsInThisQuery, page, take);
        }
    }
}
