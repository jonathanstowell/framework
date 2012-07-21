using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Dashboard.LoginStatisticsYearly.Entities
{
    [Serializable]
    public class DashboardLoginStatisticsYearly : BusinessObject<DashboardLoginStatisticsYearly>, IBusinessObject<DashboardLoginStatisticsYearly>
    {
        public virtual Guid UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual int Year { get; set; }
    }
}
