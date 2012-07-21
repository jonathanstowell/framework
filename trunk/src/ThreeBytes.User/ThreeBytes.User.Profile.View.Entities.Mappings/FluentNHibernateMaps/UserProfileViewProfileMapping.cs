using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Profile.View.Entities.Mappings.FluentNHibernateMaps
{
    public class UserProfileViewProfileMapping : ClassMap<UserProfileViewProfile>
    {
        public UserProfileViewProfileMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("ProfileId");

            Map(x => x.ItemId);
            Map(x => x.Username);
            Map(x => x.Email);
            Map(x => x.ApplicationName);
            Map(x => x.Forename);
            Map(x => x.Surname);

            Map(x => x.CreationDateTime);
            Map(x => x.LastModifiedDateTime).Nullable();

            HasMany(x => x.ExternalAuthentications)
                .KeyColumn("ProfileId")
                .Inverse()
                .Cascade.All();

            Table("ProfileViewProfiles");
        }
    }
}
