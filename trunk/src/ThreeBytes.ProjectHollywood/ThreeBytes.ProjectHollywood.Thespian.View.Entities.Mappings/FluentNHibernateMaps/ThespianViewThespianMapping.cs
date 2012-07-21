using FluentNHibernate.Mapping;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Entities.Mappings.FluentNHibernateMaps
{
    public class ThespianViewThespianMapping : ClassMap<ThespianViewThespian>
    {
        public ThespianViewThespianMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid().Column("ThespianId");

            Map(x => x.ItemId);

            Map(x => x.FirstName).Length(35).Not.Nullable();
            Map(x => x.LastName).Length(35).Not.Nullable();
            Map(x => x.ProfileImageLocation).Nullable();
            Map(x => x.ProfileThumbnailImageLocation).Nullable();
            Map(x => x.DateOfBirth).Nullable();
            Map(x => x.Gender).Length(6).Not.Nullable();
            Map(x => x.Email).Length(320).Nullable();
            Map(x => x.Location).Length(200).Nullable();
            Map(x => x.Height).Nullable();
            Map(x => x.Weight).Nullable();
            Map(x => x.PlayingAge).Nullable();
            Map(x => x.EyeColour).Length(20).Nullable();
            Map(x => x.HairLength).Length(20).Nullable();
            Map(x => x.Summary).Nullable();
            Map(x => x.Twitter).Length(20).Nullable();
            Map(x => x.Facebook).Length(255).Nullable();
            Map(x => x.Spotlight).Length(255).Nullable();
            Map(x => x.Imdb).Length(255).Nullable();
            Map(x => x.ThespianType).Length(14).Nullable();

            Map(x => x.CreatedBy).Not.Nullable().Length(35);
            Map(x => x.LastModifiedBy).Nullable().Length(35);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Map(x => x.Operation).Nullable();

            Table("ThespianViewThespians");
        }
    }
}
