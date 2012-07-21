using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Entities
{
    [Serializable]
    public class DashboardRegistrationStatisticsMonthly : BusinessObject<DashboardRegistrationStatisticsMonthly>, IBusinessObject<DashboardRegistrationStatisticsMonthly>
    {
        public virtual Guid UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual int Month { get; set; }
        public virtual int Year { get; set; }
    }
}
