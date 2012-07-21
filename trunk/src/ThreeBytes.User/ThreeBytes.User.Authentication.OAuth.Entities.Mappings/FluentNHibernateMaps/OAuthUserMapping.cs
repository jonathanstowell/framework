using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.OAuth.Entities.Mappings.FluentNHibernateMaps
{
    public class OAuthUserMapping : ClassMap<OAuthUser>
    {
        public OAuthUserMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("UserId");

            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.Email).Not.Nullable().Length(128);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            HasManyToMany(x => x.Roles)
                    .Table("AuthenticationOAuthUserRoles")
                    .ParentKeyColumn("UserId")
                    .ChildKeyColumn("RoleId")
                    .Cascade.SaveUpdate();

            HasMany(x => x.ExternalAuthentications)
                .KeyColumn("UserId")
                .Inverse()
                .Cascade.All();

            Table("AuthenticationOAuthUsers");
        }
    }
}
