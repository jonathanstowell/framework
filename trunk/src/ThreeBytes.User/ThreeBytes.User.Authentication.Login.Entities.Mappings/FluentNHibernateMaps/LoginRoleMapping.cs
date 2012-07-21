using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.Login.Entities.Mappings.FluentNHibernateMaps
{
    public class LoginRoleMapping : ClassMap<LoginRole>
    {
        public LoginRoleMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("RoleId");

            Map(x => x.Name).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            HasManyToMany(x => x.Users)
                .Table("AuthenticationLoginUserRoles")
                .ParentKeyColumn("RoleId")
                .ChildKeyColumn("UserId")
                .Inverse()
                .Cascade.None();

            Table("AuthenticationLoginRoles");
        }
    }
}
