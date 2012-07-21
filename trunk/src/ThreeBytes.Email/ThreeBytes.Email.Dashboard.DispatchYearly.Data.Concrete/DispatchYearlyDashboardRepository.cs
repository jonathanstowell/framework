using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dashboard.DispatchYearly.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchYearly.Data.Abstract.Infrastructure;
using ThreeBytes.Email.Dashboard.DispatchYearly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Data.Concrete
{
    public class DispatchYearlyDashboardRepository : KeyedGenericRepository<DashboardDispatchYearlyEmail>, IDispatchYearlyDashboardRepository
    {
        public DispatchYearlyDashboardRepository(IDispatchYearlyDashboardDatabaseFactory databaseFactory, IDispatchYearlyDashboardUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public int GetThisYearsDispatchCount(string applicationName)
        {
            return Session.QueryOver<DashboardDispatchYearlyEmail>()
                .Where(x => x.Year == DateTime.Today.Year)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();
        }

        public int[] GetPreviousYearsDispatchCounts(string applicationName)
        {
            var counts = Session.QueryOver<DashboardDispatchYearlyEmail>()
                .Select(
                    Projections.Group<DashboardDispatchYearlyEmail>(x => x.Year),
                    Projections.Count<DashboardDispatchYearlyEmail>(x => x.Id))
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
    }
}
