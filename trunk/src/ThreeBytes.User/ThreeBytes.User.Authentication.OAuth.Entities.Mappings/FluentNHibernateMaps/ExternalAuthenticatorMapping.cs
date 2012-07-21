using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.OAuth.Entities.Mappings.FluentNHibernateMaps
{
    public class ExternalAuthenticatorMapping : ClassMap<ExternalAuthenticator>
    {
        public ExternalAuthenticatorMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("ExternalAuthenticatorId");

            Map(x => x.ExternalIdentifier);
            Map(x => x.Username);
            Map(x => x.Email);
            Map(x => x.Token);
            Map(x => x.TokenSecret);
            Map(x => x.ExternalAuthenticationType);

            References(x => x.User).Column("UserId");

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("AuthenticationOAuthExternalAuthenticators");
        }
    }
}
