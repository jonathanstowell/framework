using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Authentication.Password.Entities.Mappings.FluentNHibernateMaps
{
    public class PasswordManagementUserMapping : ClassMap<PasswordManagementUser>
    {
        public PasswordManagementUserMapping()
        {
            Id(x => x.Id).Column("UserId").GeneratedBy.Assigned().Column("UserId"); ;

            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.Email).Not.Nullable().Length(128);
            Map(x => x.Password).Not.Nullable().Length(64);
            Map(x => x.ConfirmPassword).Not.Nullable().Length(64);
            Map(x => x.IsVerified).Nullable();
            Map(x => x.IsLockedOut).Nullable();
            Map(x => x.UnlockCode).Nullable();
            Map(x => x.ResetPasswordCode).Nullable();
            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("AuthenticationPasswordManagementUser");
        }
    }
}
