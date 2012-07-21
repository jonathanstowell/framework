using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Dashboard.NewestUsers.Entities.Mappings.FluentNHibernateMaps
{
    public class DashboardNewestUsersMapping : ClassMap<DashboardNewestUsers>
    {
        public DashboardNewestUsersMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("NewestUserId");

            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.RegistrationDateTime).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("DashboardNewestUsers");
        }
    }
}
