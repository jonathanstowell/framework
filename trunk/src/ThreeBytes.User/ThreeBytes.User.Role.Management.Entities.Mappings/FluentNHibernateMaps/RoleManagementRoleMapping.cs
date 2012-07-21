using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Role.Management.Entities.Mappings.FluentNHibernateMaps
{
    public class RoleManagementRoleMapping : ClassMap<RoleManagementRole>
    {
        public RoleManagementRoleMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("RoleId");

            Map(x => x.Name).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("RoleManagementRoles");
        }
    }
}
