using System;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Entities;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Service.Abstract
{
    public interface IDashboardRegistrationStatisticsYearlyService : IKeyedGenericService<DashboardRegistrationStatisticsYearly>
    {
        int GetThisYearsRegistrationCount(string applicationName);
        int[] GetPreviousYearsRegistrationCounts(string applicationName);
        IPagedResult<DashboardRegistrationStatisticsYearly> GetPagedYearRegistrationsFor(int take, DateTime? originalRequestDateTime, string applicationName, int year, int page = 1);
    }
}
