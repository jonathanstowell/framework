using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.UserManagement.Entities.Mappings.FluentNHibernateMaps
{
    public class UserManagementUserMapping : ClassMap<AuthenticationUserManagementUser>
    {
        public UserManagementUserMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("UserId");

            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.Email).Not.Nullable().Length(128);
            Map(x => x.IsVerified).Nullable();
            Map(x => x.VerifiedCode).Nullable();
            Map(x => x.IsLockedOut).Nullable();
            Map(x => x.UnlockCode).Nullable();
            Map(x => x.FailedPasswordAttemptCount).Nullable();
            Map(x => x.FailedPasswordAttemptWindowStart).Nullable();

            HasManyToMany(x => x.Roles)
                    .Table("AuthenticationUserManagementUserRoles")
                    .ParentKeyColumn("UserId")
                    .ChildKeyColumn("RoleId")
                    .Cascade.SaveUpdate()
                    .Not.LazyLoad();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("AuthenticationUserManagementUsers");
        }
    }
}
