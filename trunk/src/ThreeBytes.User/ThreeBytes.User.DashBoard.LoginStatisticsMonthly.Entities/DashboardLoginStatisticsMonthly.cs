using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Entities
{
    [Serializable]
    public class DashboardLoginStatisticsMonthly : BusinessObject<DashboardLoginStatisticsMonthly>, IBusinessObject<DashboardLoginStatisticsMonthly>
    {
        public virtual Guid UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual int Month { get; set; }
        public virtual int Year { get; set; }
    }
}
