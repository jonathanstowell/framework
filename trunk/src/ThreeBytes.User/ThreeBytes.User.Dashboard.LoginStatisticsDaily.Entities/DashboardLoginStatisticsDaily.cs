using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Entities
{
    [Serializable]
    public class DashboardLoginStatisticsDaily : BusinessObject<DashboardLoginStatisticsDaily>, IBusinessObject<DashboardLoginStatisticsDaily>
    {
        public virtual Guid UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual DateTime LoginDate { get; set; }
    }
}
