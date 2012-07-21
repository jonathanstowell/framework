using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.OAuth.Entities.Mappings.FluentNHibernateMaps
{
    public class OAuthRoleMapping : ClassMap<OAuthRole>
    {
        public OAuthRoleMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("RoleId");

            Map(x => x.Name).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            HasManyToMany(x => x.Users)
                .Table("AuthenticationOAuthUserRoles")
                .ParentKeyColumn("RoleId")
                .ChildKeyColumn("UserId")
                .Inverse()
                .Cascade.SaveUpdate();

            Table("AuthenticationOAuthRoles");
        }
    }
}
