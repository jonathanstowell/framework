using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.UserManagement.Entities.Mappings.FluentNHibernateMaps
{
    public class UserManagementRoleMapping : ClassMap<AuthenticationUserManagementRole>
    {
        public UserManagementRoleMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("RoleId");

            Map(x => x.Name).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            HasManyToMany(x => x.Users)
                .Table("AuthenticationUserManagementUserRoles")
                .ParentKeyColumn("RoleId")
                .ChildKeyColumn("UserId")
                .Inverse()
                .Cascade.SaveUpdate()
                .Not.LazyLoad();

            Table("AuthenticationUserManagementRoles");
        }
    }
}
