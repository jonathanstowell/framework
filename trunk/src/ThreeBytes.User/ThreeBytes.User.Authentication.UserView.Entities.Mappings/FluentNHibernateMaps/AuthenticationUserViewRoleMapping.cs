using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.UserView.Entities.Mappings.FluentNHibernateMaps
{
    public class AuthenticationUserViewRoleMapping : ClassMap<AuthenticationUserViewRole>
    {
        public AuthenticationUserViewRoleMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("RoleId");

            Map(x => x.Name).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);

            HasManyToMany(x => x.Users)
                .Table("AuthenticationUserViewUserRoles")
                .ParentKeyColumn("RoleId")
                .ChildKeyColumn("UserId")
                .Inverse()
                .Cascade.None();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("AuthenticationUserViewRoles");
        }
    }
}
