using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.Login.Entities.Mappings.FluentNHibernateMaps
{
    public class LoginUserMapping : ClassMap<LoginUser>
    {
        public LoginUserMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("UserId");

            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.Email).Not.Nullable().Length(128);
            Map(x => x.Password).Not.Nullable().Length(64);
            Map(x => x.IsVerified).Nullable();
            Map(x => x.IsLockedOut).Nullable();
            Map(x => x.FailedPasswordAttemptCount).Nullable();
            Map(x => x.FailedPasswordAttemptWindowStart).Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            HasManyToMany(x => x.Roles)
                    .Table("AuthenticationLoginUserRoles")
                    .ParentKeyColumn("UserId")
                    .ChildKeyColumn("RoleId")
                    .Cascade.SaveUpdate();

            Table("AuthenticationLoginUsers");
        }
    }
}
