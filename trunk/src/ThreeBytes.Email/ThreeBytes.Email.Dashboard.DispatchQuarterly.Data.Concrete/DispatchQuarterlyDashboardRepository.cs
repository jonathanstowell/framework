using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Configuration.Abstract;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Data.Abstract;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Data.Abstract.Infrastructure;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Entities;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Data.Concrete
{
    public class DispatchQuarterlyDashboardRepository : KeyedGenericRepository<DashboardDispatchQuarterlyEmail>, IDispatchQuarterlyDashboardRepository
    {
        private readonly IProvideEmailDispatchQuarterlyConfiguration configuration;

        public DispatchQuarterlyDashboardRepository(IDispatchQuarterlyDashboardDatabaseFactory databaseFactory, IDispatchQuarterlyDashboardUnitOfWork unitOfWork, IProvideEmailDispatchQuarterlyConfiguration configuration)
            : base(databaseFactory, unitOfWork)
        {
            this.configuration = configuration;
        }

        public int GetThisQuartersDispatchCount(string applicationName)
        {
            return Session.QueryOver<DashboardDispatchQuarterlyEmail>()
                .Where(x => x.Quarter == configuration.GetThisQuarter)
                .And(x => x.Year == DateTime.Today.Year)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();
        }

        public int[] GetLastFourQuartersDispatchCounts(string applicationName)
        {
            var counts = Session.QueryOver<DashboardDispatchQuarterlyEmail>()
                .Select(
                    Projections.Group<DashboardDispatchQuarterlyEmail>(x => x.Quarter),
                    Projections.Group<DashboardDispatchQuarterlyEmail>(x => x.Year),
                    Projections.Count<DashboardDispatchQuarterlyEmail>(x => x.Id))
                .And(x => x.ApplicationName == applicationName)
                .OrderBy(x => x.Quarter).Desc
                .OrderBy(x => x.Year).Desc
                .Take(4)
                .List<object[]>();

            var ret = new List<int>();

            if (counts.Count == 4)
                return counts.Select(x => (int)x[2]).ToArray();

            for (int i = 0; i < (4 - counts.Count); i++)
            {
                ret.Add(0);
            }

            ret.AddRange(counts.Select(x => (int)x[2]).ToList());

            return ret.ToArray();
        }
    }
}
