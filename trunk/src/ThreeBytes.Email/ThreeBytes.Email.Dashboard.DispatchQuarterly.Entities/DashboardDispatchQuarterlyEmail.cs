using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Entities
{
    public class DashboardDispatchQuarterlyEmail : BusinessObject<DashboardDispatchQuarterlyEmail>, IBusinessObject<DashboardDispatchQuarterlyEmail>
    {
        public virtual string ApplicationName { get; set; }
        public virtual string To { get; set; }
        public virtual string Subject { get; set; }
        public virtual int Quarter { get; set; }
        public virtual int Year { get; set; }
    }
}
