using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.UserView.Entities.Mappings.FluentNHibernateMaps
{
    public class AuthenticationUserViewUserMapping : ClassMap<AuthenticationUserViewUser>
    {
        public AuthenticationUserViewUserMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("UserId");

            Map(x => x.ItemId).Not.Nullable();

            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.Email).Not.Nullable().Length(128);
            Map(x => x.IsVerified).Nullable();
            Map(x => x.VerifiedCode).Nullable();
            Map(x => x.IsOriginalAdministrator).Nullable();
            Map(x => x.IsLockedOut).Nullable();
            Map(x => x.UnlockCode).Nullable();
            Map(x => x.FailedPasswordAttemptCount).Nullable();
            Map(x => x.FailedPasswordAttemptWindowStart).Nullable();

            HasManyToMany(x => x.Roles)
                    .Table("AuthenticationUserViewUserRoles")
                    .ParentKeyColumn("UserId")
                    .ChildKeyColumn("RoleId")
                    .Cascade.SaveUpdate();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Map(x => x.Operation).Nullable();

            Table("AuthenticationUserViewUsers");
        }
    }
}
