using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Data.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Data.Abstract.Infrastructure;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Data.Concrete
{
    public class DashboardRegistrationStatisticsDailyRepository : KeyedGenericRepository<DashboardRegistrationStatisticsDaily>, IDashboardDailyRegistrationRepository
    {
        public DashboardRegistrationStatisticsDailyRepository(IDashboardRegistrationStatisticsDailyDatabaseFactory databaseFactory, IDashboardRegistrationStatisticsDailyUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public int GetTodaysRegistrationCount(string applicationName)
        {
            return Session.QueryOver<DashboardRegistrationStatisticsDaily>()
                .Where(x => x.RegistrationDateTime == DateTime.Today)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();
        }

        public int[] GetLastThirtyDaysRegistrationCounts(string applicationName)
        {
            var counts = Session.QueryOver<DashboardRegistrationStatisticsDaily>()
                .Select(
                    Projections.Group<DashboardRegistrationStatisticsDaily>(x => x.RegistrationDateTime),
                    Projections.Count<DashboardRegistrationStatisticsDaily>(x => x.RegistrationDateTime))
                .Where(x => x.RegistrationDateTime >= DateTime.Today.AddDays(-30))
                .And(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.RegistrationDateTime).Desc
                .Take(30)
                .List<object[]>();

            var ret = new List<int>();

            if (counts.Count == 30)
                return counts.Select(x => (int)x[1]).ToArray();

            for (int i = 0; i < (30 - counts.Count); i++)
            {
                ret.Add(0);
            }

            ret.AddRange(counts.Select(x => (int)x[1]).ToList());

            return ret.ToArray();
        }

        public IPagedResult<DashboardRegistrationStatisticsDaily> GetPagedDailyRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, DateTime day, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<DashboardRegistrationStatisticsDaily> pagedDailyLogins = Session.QueryOver<DashboardRegistrationStatisticsDaily>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.RegistrationDateTime == day)
                .OrderBy(x => x.Username).Asc
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<DashboardRegistrationStatisticsDaily>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.RegistrationDateTime == day)
                .RowCount();

            return new PagedResult<DashboardRegistrationStatisticsDaily>(pagedDailyLogins, originalRequest, recordsInThisQuery, page, take);
        }
    }
}
