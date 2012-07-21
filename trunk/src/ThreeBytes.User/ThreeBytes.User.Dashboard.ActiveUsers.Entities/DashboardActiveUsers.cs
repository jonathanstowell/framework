using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Entities
{
    [Serializable]
    public class DashboardActiveUsers : BusinessObject<DashboardActiveUsers>, IBusinessObject<DashboardActiveUsers>
    {
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual int Logins { get; set; }
    }
}
