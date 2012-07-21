using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.Registration.Entities.Mappings.FluentNHibernateMaps
{
    public class RegistrationUserMapping : ClassMap<RegistrationUser>
    {
        public RegistrationUserMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("UserId");

            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.Email).Not.Nullable().Length(128);
            Map(x => x.IsVerified).Nullable();
            Map(x => x.VerifiedCode).Not.Nullable();
            Map(x => x.Password).Not.Nullable().Length(64);
            Map(x => x.ConfirmPassword).Not.Nullable().Length(64);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("AuthenticationRegistrationUsers");
        }
    }
}
