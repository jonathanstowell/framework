using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Entities
{
    [Serializable]
    public class DashboardRegistrationStatisticsQuarterly : BusinessObject<DashboardRegistrationStatisticsQuarterly>, IBusinessObject<DashboardRegistrationStatisticsQuarterly>
    {
        public virtual Guid UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual int Quarter { get; set; }
        public virtual int Year { get; set; }
    }
}
