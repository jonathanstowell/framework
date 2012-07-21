using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Data.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Data.Abstract.Infrastructure;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Data.Concrete
{
    public class DashboardRegistrationStatisticsMonthlyRepository : KeyedGenericRepository<DashboardRegistrationStatisticsMonthly>, IDashboardRegistrationStatisticsMonthlyRepository
    {
        public DashboardRegistrationStatisticsMonthlyRepository(IDashboardRegistrationStatisticsMonthlyDatabaseFactory databaseFactory, IDashboardRegistrationStatisticsMonthlyUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public int GetThisMonthsRegistrationCount(string applicationName)
        {
            return Session.QueryOver<DashboardRegistrationStatisticsMonthly>()
                .Where(x => x.Month == DateTime.Today.Month)
                .And(x => x.Year == DateTime.Today.Year)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();
        }

        public int[] GetLastTwelveMonthsRegistrationCounts(string applicationName)
        {
            var twelveMonthsAgo = DateTime.Today.AddYears(-1);

            var counts = Session.QueryOver<DashboardRegistrationStatisticsMonthly>()
                .Select(
                    Projections.Group<DashboardRegistrationStatisticsMonthly>(x => x.Month),
                    Projections.Group<DashboardRegistrationStatisticsMonthly>(x => x.Year),
                    Projections.Count<DashboardRegistrationStatisticsMonthly>(x => x.Id))
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

        public IPagedResult<DashboardRegistrationStatisticsMonthly> GetPagedMonthlyRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, int month, int year, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<DashboardRegistrationStatisticsMonthly> pagedDailyLogins = Session.QueryOver<DashboardRegistrationStatisticsMonthly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.Month == DateTime.Today.Month)
                       .And(x => x.Year == DateTime.Today.Year)
                .OrderBy(x => x.Username).Asc
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<DashboardRegistrationStatisticsMonthly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.Month == DateTime.Today.Month)
                .And(x => x.Year == DateTime.Today.Year)
                .RowCount();

            return new PagedResult<DashboardRegistrationStatisticsMonthly>(pagedDailyLogins, originalRequest, recordsInThisQuery, page, take);
        }
    }
}
