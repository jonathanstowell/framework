using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Entities
{
    [Serializable]
    public class DashboardLoginStatisticsQuarterly : BusinessObject<DashboardLoginStatisticsQuarterly>, IBusinessObject<DashboardLoginStatisticsQuarterly>
    {
        public virtual Guid UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual int Quarter { get; set; }
        public virtual int Year { get; set; }
    }
}
