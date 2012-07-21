using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.Registration.Entities.Mappings.FluentNHibernateMaps
{
    public class ExternalAuthenticatorMapping : ClassMap<ExternalAuthenticator>
    {
        public ExternalAuthenticatorMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("ExternalAuthenticatorId");

            Map(x => x.ExternalIdentifier);
            Map(x => x.ApplicationName);
            Map(x => x.Username);
            Map(x => x.Email);
            Map(x => x.ExternalAuthenticationType);

            References(x => x.User).Column("UserId");

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("AuthenticationRegistrationExternalAuthenticators");
        }
    }
}
