using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.UserList.Entities.Mappings.FluentNHibernateMaps
{
    public class AuthenticationUserListUserMapping : ClassMap<AuthenticationUserListUser>
    {
        public AuthenticationUserListUserMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("UserId");

            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.Email).Not.Nullable().Length(128);
            Map(x => x.IsVerified).Nullable();
            Map(x => x.IsLockedOut).Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("AuthenticationUserListUsers");
        }
    }
}
