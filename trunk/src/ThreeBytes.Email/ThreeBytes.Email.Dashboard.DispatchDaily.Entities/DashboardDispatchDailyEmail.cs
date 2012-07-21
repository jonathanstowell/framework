using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.Email.Dashboard.DispatchDaily.Entities
{
    public class DashboardDispatchDailyEmail : BusinessObject<DashboardDispatchDailyEmail>, IBusinessObject<DashboardDispatchDailyEmail>
    {
        public virtual string ApplicationName { get; set; }
        public virtual string To { get; set; }
        public virtual string Subject { get; set; }
        public virtual DateTime DispatchDate { get; set; }
    }
}
