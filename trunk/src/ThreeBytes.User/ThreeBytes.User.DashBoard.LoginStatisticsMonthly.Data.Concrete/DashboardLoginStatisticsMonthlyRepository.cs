using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Data.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Data.Abstract.Infrastructure;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Entities;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Data.Concrete
{
    public class DashboardLoginStatisticsMonthlyRepository : KeyedGenericRepository<DashboardLoginStatisticsMonthly>, IDashboardLoginStatisticsMonthlyRepository
    {
        public DashboardLoginStatisticsMonthlyRepository(IDashboardLoginStatisticsMonthlyDatabaseFactory databaseFactory, IDashboardLoginStatisticsMonthlyUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public int GetThisMonthsLoginCount(string applicationName)
        {
            return Session.QueryOver<DashboardLoginStatisticsMonthly>()
                .Where(x => x.Month == DateTime.Today.Month)
                .And(x => x.Year == DateTime.Today.Year)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();
        }

        public int[] GetLastTwelveMonthsLoginCounts(string applicationName)
        {
            var twelveMonthsAgo = DateTime.Today.AddYears(-1);

            var counts = Session.QueryOver<DashboardLoginStatisticsMonthly>()
                .Select(
                    Projections.Group<DashboardLoginStatisticsMonthly>(x => x.Month),
                    Projections.Group<DashboardLoginStatisticsMonthly>(x => x.Year),
                    Projections.Count<DashboardLoginStatisticsMonthly>(x => x.Id))
                .Where(x => x.Month >= twelveMonthsAgo.Month)
                .And(x => x.Year >= twelveMonthsAgo.Year)
                .And(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.Month).Desc
                .OrderBy(x => x.Year).Desc
                .Take(12)
                .List<object[]>();

            var ret = new List<int>();

            if (counts.Count == 12)
                return counts.Select(x => (int)x[2]).ToArray();

            for (int i = 0; i < (12 - counts.Count); i++)
            {
                ret.Add(0);
            }

            ret.AddRange(counts.Select(x => (int)x[2]).ToList());

            return ret.ToArray();
        }

        public bool HasUserHasLoggedInThisMonth(Guid userId, string applicationName)
        {
            return Session.QueryOver<DashboardLoginStatisticsMonthly>()
                       .Where(x => x.UserId == userId)
                       .And(x => x.ApplicationName == applicationName)
                       .And(x => x.Month == DateTime.Today.Month)
                       .And(x => x.Year == DateTime.Today.Year)
                       .RowCount() > 0;
        }

        public IPagedResult<DashboardLoginStatisticsMonthly> GetPagedMonthlyLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, int month, int year, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<DashboardLoginStatisticsMonthly> pagedDailyLogins = Session.QueryOver<DashboardLoginStatisticsMonthly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.Month == DateTime.Today.Month)
                       .And(x => x.Year == DateTime.Today.Year)
                .OrderBy(x => x.Username).Asc
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<DashboardLoginStatisticsMonthly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.Month == DateTime.Today.Month)
                .And(x => x.Year == DateTime.Today.Year)
                .RowCount();

            return new PagedResult<DashboardLoginStatisticsMonthly>(pagedDailyLogins, originalRequest, recordsInThisQuery, page, take);
        }
    }
}
