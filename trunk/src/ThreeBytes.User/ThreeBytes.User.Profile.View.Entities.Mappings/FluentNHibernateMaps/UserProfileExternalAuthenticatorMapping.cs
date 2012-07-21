using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Profile.View.Entities.Mappings.FluentNHibernateMaps
{
    public class UserProfileExternalAuthenticatorMapping : ClassMap<UserProfileExternalAuthenticator>
    {
        public UserProfileExternalAuthenticatorMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("ExternalAuthenticatorId");

            Map(x => x.ExternalIdentifier);
            Map(x => x.Username);
            Map(x => x.Email);
            Map(x => x.ExternalAuthenticationType);

            References(x => x.User).Column("ProfileId");

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("ProfileViewExternalAuthenticators");
        }
    }
}
