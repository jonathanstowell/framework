using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Data.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Data.Abstract.Infrastructure;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Entities;

namespace ThreeBytes.User.Dashboard.LoginStatisticsYearly.Data.Concrete
{
    public class DashboardLoginStatisticsYearlyRepository : KeyedGenericRepository<DashboardLoginStatisticsYearly>, IDashboardLoginStatisticsYearlyRepository
    {
        public DashboardLoginStatisticsYearlyRepository(IDashboardLoginStatisticsYearlyDatabaseFactory databaseFactory, IDashboardLoginStatisticsYearlyUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public int GetThisYearsLoginCount(string applicationName)
        {
            return Session.QueryOver<DashboardLoginStatisticsYearly>()
                .Where(x => x.Year == DateTime.Today.Year)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();
        }

        public int[] GetPreviousYearsLoginCounts(string applicationName)
        {
            var counts = Session.QueryOver<DashboardLoginStatisticsYearly>()
                .Select(
                    Projections.Group<DashboardLoginStatisticsYearly>(x => x.Year),
                    Projections.Count<DashboardLoginStatisticsYearly>(x => x.Id))
                .And(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.Year).Desc
                .Take(4)
                .List<object[]>();

            var ret = new List<int>();

            if (counts.Count == 4)
                return counts.Select(x => (int)x[1]).ToArray();

            for (int i = 0; i < (4 - counts.Count); i++)
            {
                ret.Add(0);
            }

            ret.AddRange(counts.Select(x => (int)x[1]).ToList());

            return ret.ToArray();
        }

        public bool HasUserHasLoggedInThisYear(Guid userId, string applicationName)
        {
            return Session.QueryOver<DashboardLoginStatisticsYearly>()
                       .Where(x => x.UserId == userId)
                       .And(x => x.ApplicationName == applicationName)
                       .And(x => x.Year == DateTime.Today.Year)
                       .RowCount() > 0;
        }

        public IPagedResult<DashboardLoginStatisticsYearly> GetPagedYearLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, int year, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<DashboardLoginStatisticsYearly> pagedQuarterlyLogins = Session.QueryOver<DashboardLoginStatisticsYearly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .And(x => x.Year == DateTime.Today.Year)
                .OrderBy(x => x.Username).Asc
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<DashboardLoginStatisticsYearly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .And(x => x.Year == DateTime.Today.Year)
                .RowCount();

            return new PagedResult<DashboardLoginStatisticsYearly>(pagedQuarterlyLogins, originalRequest, recordsInThisQuery, page, take);
        }
    }
}
