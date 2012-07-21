using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Entities.Mappings.FluentNHibernateMaps
{
    public class DashboardActiveUsersMapping : ClassMap<DashboardActiveUsers>
    {
        public DashboardActiveUsersMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("ActiveUserId");

            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.Logins).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("DashboardActiveUsers");
        }
    }
}
