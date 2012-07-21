using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Data.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Data.Abstract.Infrastructure;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Data.Concrete
{
    public class DashboardRegistrationStatisticsYearlyRepository : KeyedGenericRepository<DashboardRegistrationStatisticsYearly>, IDashboardRegistrationStatisticsYearlyRepository
    {
        public DashboardRegistrationStatisticsYearlyRepository(IDashboardRegistrationStatisticsYearlyDatabaseFactory databaseFactory, IDashboardRegistrationStatisticsYearlyUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public int GetThisYearsRegistrationCount(string applicationName)
        {
            return Session.QueryOver<DashboardRegistrationStatisticsYearly>()
                .Where(x => x.Year == DateTime.Today.Year)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();
        }

        public int[] GetPreviousYearsRegistrationCounts(string applicationName)
        {
            var counts = Session.QueryOver<DashboardRegistrationStatisticsYearly>()
                .Select(
                    Projections.Group<DashboardRegistrationStatisticsYearly>(x => x.Year),
                    Projections.Count<DashboardRegistrationStatisticsYearly>(x => x.Id))
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

        public IPagedResult<DashboardRegistrationStatisticsYearly> GetPagedYearRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, int year, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<DashboardRegistrationStatisticsYearly> pagedQuarterlyLogins = Session.QueryOver<DashboardRegistrationStatisticsYearly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .And(x => x.Year == DateTime.Today.Year)
                .OrderBy(x => x.Username).Asc
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<DashboardRegistrationStatisticsYearly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .And(x => x.Year == DateTime.Today.Year)
                .RowCount();

            return new PagedResult<DashboardRegistrationStatisticsYearly>(pagedQuarterlyLogins, originalRequest, recordsInThisQuery, page, take);
        }
    }
}
