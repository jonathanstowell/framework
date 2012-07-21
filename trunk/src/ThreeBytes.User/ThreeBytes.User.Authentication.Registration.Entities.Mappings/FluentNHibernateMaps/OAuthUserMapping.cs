using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.Registration.Entities.Mappings.FluentNHibernateMaps
{
    public class OAuthUserMapping : ClassMap<ExternalUser>
    {
        public OAuthUserMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("UserId");

            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            HasMany(x => x.ExternalAuthentications)
                .KeyColumn("UserId")
                .Inverse()
                .Cascade.All();

            Table("AuthenticationRegistrationExternalUsers");
        }
    }
}
