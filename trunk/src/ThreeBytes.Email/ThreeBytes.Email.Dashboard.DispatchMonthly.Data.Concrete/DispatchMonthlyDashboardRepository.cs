using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Data.Abstract.Infrastructure;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Data.Concrete
{
    public class DispatchMonthlyDashboardRepository : KeyedGenericRepository<DashboardDispatchMonthlyEmail>, IDispatchMonthlyDashboardRepository
    {
        public DispatchMonthlyDashboardRepository(IDispatchMonthlyDashboardDatabaseFactory databaseFactory, IDispatchMonthlyDashboardUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public int GetThisMonthsDispatchCount(string applicationName)
        {
            return Session.QueryOver<DashboardDispatchMonthlyEmail>()
                .Where(x => x.Month == DateTime.Today.Month)
                .And(x => x.Year == DateTime.Today.Year)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();
        }

        public int[] GetLastTwelveMonthsDispatchCounts(string applicationName)
        {
            var twelveMonthsAgo = DateTime.Today.AddYears(-1);

            var counts = Session.QueryOver<DashboardDispatchMonthlyEmail>()
                .Select(
                    Projections.Group<DashboardDispatchMonthlyEmail>(x => x.Month),
                    Projections.Group<DashboardDispatchMonthlyEmail>(x => x.Year),
                    Projections.Count<DashboardDispatchMonthlyEmail>(x => x.Id))
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
    }
}
