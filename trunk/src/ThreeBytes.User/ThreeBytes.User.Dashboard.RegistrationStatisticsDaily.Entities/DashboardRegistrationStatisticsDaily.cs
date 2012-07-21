using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Entities
{
    [Serializable]
    public class DashboardRegistrationStatisticsDaily : BusinessObject<DashboardRegistrationStatisticsDaily>, IBusinessObject<DashboardRegistrationStatisticsDaily>
    {
        public virtual Guid UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual DateTime RegistrationDateTime { get; set; }
    }
}
