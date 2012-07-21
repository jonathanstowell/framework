using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Configuration.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Abstract.Infrastructure;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Data.Concrete
{
    public class DashboardRegistrationStatisticsQuarterlyRepository : KeyedGenericRepository<DashboardRegistrationStatisticsQuarterly>, IDashboardRegistrationStatisticsQuarterlyRepository
    {
        private readonly IProvideRegistrationStatisticsQuarterlyConfiguration configuration;

        public DashboardRegistrationStatisticsQuarterlyRepository(IDashboardRegistrationStatisticsQuarterlyDatabaseFactory databaseFactory, IDashboardRegistrationStatisticsQuarterlyUnitOfWork unitOfWork, IProvideRegistrationStatisticsQuarterlyConfiguration configuration)
            : base(databaseFactory, unitOfWork)
        {
            this.configuration = configuration;
        }

        public int GetThisQuartersRegistrationCount(string applicationName)
        {
            return Session.QueryOver<DashboardRegistrationStatisticsQuarterly>()
                .Where(x => x.Quarter == configuration.GetThisQuarter)
                .And(x => x.Year == DateTime.Today.Year)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();
        }

        public int[] GetLastFourQuartersRegistrationCounts(string applicationName)
        {
            var counts = Session.QueryOver<DashboardRegistrationStatisticsQuarterly>()
                .Select(
                    Projections.Group<DashboardRegistrationStatisticsQuarterly>(x => x.Quarter),
                    Projections.Group<DashboardRegistrationStatisticsQuarterly>(x => x.Year),
                    Projections.Count<DashboardRegistrationStatisticsQuarterly>(x => x.Id))
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

        public IPagedResult<DashboardRegistrationStatisticsQuarterly> GetPagedQuarterRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, int quarter, int year, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<DashboardRegistrationStatisticsQuarterly> pagedQuarterlyLogins = Session.QueryOver<DashboardRegistrationStatisticsQuarterly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .And(x => x.Quarter == quarter)
                .And(x => x.Year == DateTime.Today.Year)
                .OrderBy(x => x.Username).Asc
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<DashboardRegistrationStatisticsQuarterly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .And(x => x.Quarter == quarter)
                .And(x => x.Year == DateTime.Today.Year)
                .RowCount();

            return new PagedResult<DashboardRegistrationStatisticsQuarterly>(pagedQuarterlyLogins, originalRequest, recordsInThisQuery, page, take);
        }
    }
}
