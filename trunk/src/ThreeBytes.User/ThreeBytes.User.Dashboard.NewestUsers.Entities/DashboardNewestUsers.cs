using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.User.Dashboard.NewestUsers.Entities
{
    [Serializable]
    public class DashboardNewestUsers : BusinessObject<DashboardNewestUsers>, IBusinessObject<DashboardNewestUsers>
    {
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual DateTime RegistrationDateTime { get; set; }
    }
}
