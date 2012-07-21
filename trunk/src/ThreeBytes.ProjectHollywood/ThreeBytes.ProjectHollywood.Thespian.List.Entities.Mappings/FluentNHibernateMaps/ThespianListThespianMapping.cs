using FluentNHibernate.Mapping;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Entities.Mappings.FluentNHibernateMaps
{
    public class ThespianListThespianMapping : ClassMap<ThespianListThespian>
    {
        public ThespianListThespianMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("ThespianId");

            Map(x => x.FirstName).Length(35).Not.Nullable();
            Map(x => x.LastName).Length(35).Not.Nullable();
            Map(x => x.ProfileImageLocation).Nullable();
            Map(x => x.ProfileThumbnailImageLocation).Nullable();
            Map(x => x.Gender).Length(6).Not.Nullable();
            Map(x => x.ThespianType).Length(14).Nullable();

            Map(x => x.CreatedBy).Not.Nullable().Length(35);
            Map(x => x.LastModifiedBy).Nullable().Length(35);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("ThespianListThespians");
        }
    }
}
