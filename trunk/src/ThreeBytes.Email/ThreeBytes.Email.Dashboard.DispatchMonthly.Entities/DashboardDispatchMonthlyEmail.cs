using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Entities
{
    public class DashboardDispatchMonthlyEmail : BusinessObject<DashboardDispatchMonthlyEmail>, IBusinessObject<DashboardDispatchMonthlyEmail>
    {
        public virtual string ApplicationName { get; set; }
        public virtual string To { get; set; }
        public virtual string Subject { get; set; }
        public virtual int Month { get; set; }
        public virtual int Year { get; set; }
    }
}
