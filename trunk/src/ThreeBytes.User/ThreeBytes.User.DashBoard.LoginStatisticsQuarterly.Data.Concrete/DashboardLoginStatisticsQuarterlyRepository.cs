using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Criterion;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Data.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Data.Abstract.Infrastructure;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Entities;
using ThreeBytes.User.Dashboard.LoginStatisticsQuarterly.Configuration.Abstract;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Data.Concrete
{
    public class DashboardLoginStatisticsQuarterlyRepository : KeyedGenericRepository<DashboardLoginStatisticsQuarterly>, IDashboardLoginStatisticsQuarterlyRepository
    {
        private readonly IProvideLoginStatisticsQuarterlyConfiguration configuration;

        public DashboardLoginStatisticsQuarterlyRepository(IDashboardLoginStatisticsQuarterlyDatabaseFactory databaseFactory, IDashboardLoginStatisticsQuarterlyUnitOfWork unitOfWork, IProvideLoginStatisticsQuarterlyConfiguration configuration)
            : base(databaseFactory, unitOfWork)
        {
            this.configuration = configuration;
        }

        public int GetThisQuartersLoginCount(string applicationName)
        {
            return Session.QueryOver<DashboardLoginStatisticsQuarterly>()
                .Where(x => x.Quarter == configuration.GetThisQuarter)
                .And(x => x.Year == DateTime.Today.Year)
                .And(x => x.ApplicationName == applicationName)
                .RowCount();
        }

        public int[] GetLastFourQuartersLoginCounts(string applicationName)
        {
            var counts = Session.QueryOver<DashboardLoginStatisticsQuarterly>()
                .Select(
                    Projections.Group<DashboardLoginStatisticsQuarterly>(x => x.Quarter),
                    Projections.Group<DashboardLoginStatisticsQuarterly>(x => x.Year),
                    Projections.Count<DashboardLoginStatisticsQuarterly>(x => x.Id))
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

        public bool HasUserHasLoggedInThisQuarter(Guid userId, string applicationName)
        {
            return Session.QueryOver<DashboardLoginStatisticsQuarterly>()
                       .Where(x => x.UserId == userId)
                       .And(x => x.ApplicationName == applicationName)
                       .And(x => x.Quarter == configuration.GetThisQuarter)
                       .And(x => x.Year == DateTime.Today.Year)
                       .RowCount() > 0;
        }

        public IPagedResult<DashboardLoginStatisticsQuarterly> GetPagedQuarterLoginsFor(int take, DateTime? originalRequestDateTime, string applicationName, int quarter, int year, int page = 1)
        {
            int firstResult = (page - 1) * take;
            DateTime originalRequest = originalRequestDateTime ?? DateTime.Now;

            IList<DashboardLoginStatisticsQuarterly> pagedQuarterlyLogins = Session.QueryOver<DashboardLoginStatisticsQuarterly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .And(x => x.Quarter == quarter)
                .And(x => x.Year == DateTime.Today.Year)
                .OrderBy(x => x.Username).Asc
                .Skip(firstResult)
                .Take(take)
                .List();

            int recordsInThisQuery = Session.QueryOver<DashboardLoginStatisticsQuarterly>()
                .Where(x => x.CreationDateTime <= originalRequest)
                .And(x => x.ApplicationName == applicationName)
                .And(x => x.Quarter == quarter)
                .And(x => x.Year == DateTime.Today.Year)
                .RowCount();

            return new PagedResult<DashboardLoginStatisticsQuarterly>(pagedQuarterlyLogins, originalRequest, recordsInThisQuery, page, take);
        }
    }
}
