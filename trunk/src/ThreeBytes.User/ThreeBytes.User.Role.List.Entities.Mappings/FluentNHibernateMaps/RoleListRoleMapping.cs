using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Role.List.Entities.Mappings.FluentNHibernateMaps
{
    public class RoleListRoleMapping : ClassMap<RoleListRole>
    {
        public RoleListRoleMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("RoleId");

            Map(x => x.Name).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("RoleListRoles");
        }
    }
}
