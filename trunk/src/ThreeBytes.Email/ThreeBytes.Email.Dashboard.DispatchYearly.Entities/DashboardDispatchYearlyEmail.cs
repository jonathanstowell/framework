using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Entities
{
    public class DashboardDispatchYearlyEmail : BusinessObject<DashboardDispatchYearlyEmail>, IBusinessObject<DashboardDispatchYearlyEmail>
    {
        public virtual string ApplicationName { get; set; }
        public virtual string To { get; set; }
        public virtual string Subject { get; set; }
        public virtual int Year { get; set; }
    }
}
