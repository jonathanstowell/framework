using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Entities
{
    [Serializable]
    public class DashboardRegistrationStatisticsYearly : BusinessObject<DashboardRegistrationStatisticsYearly>, IBusinessObject<DashboardRegistrationStatisticsYearly>
    {
        public virtual Guid UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual int Year { get; set; }
    }
}
