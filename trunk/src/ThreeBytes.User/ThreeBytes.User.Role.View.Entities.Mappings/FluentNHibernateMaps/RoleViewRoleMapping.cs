using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Role.View.Entities.Mappings.FluentNHibernateMaps
{
    public class RoleViewRoleMapping : ClassMap<RoleViewRole>
    {
        public RoleViewRoleMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("RoleId");

            Map(x => x.ItemId).Nullable();

            Map(x => x.Name).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Map(x => x.Operation).Nullable();

            Table("RoleViewRoles");
        }
    }
}
