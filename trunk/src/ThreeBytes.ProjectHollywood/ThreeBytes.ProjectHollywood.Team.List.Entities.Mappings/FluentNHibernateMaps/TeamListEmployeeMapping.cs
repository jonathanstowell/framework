using FluentNHibernate.Mapping;

namespace ThreeBytes.ProjectHollywood.Team.List.Entities.Mappings.FluentNHibernateMaps
{
    public class TeamListEmployeeMapping : ClassMap<TeamListEmployee>
    {
        public TeamListEmployeeMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("EmployeeId");

            Map(x => x.FirstName).Length(35).Not.Nullable();
            Map(x => x.LastName).Length(35).Not.Nullable();
            Map(x => x.JobTitle).Length(50).Not.Nullable();
            Map(x => x.ProfileImageLocation).Nullable();
            Map(x => x.ProfileThumbnailImageLocation).Nullable();

            Map(x => x.CreatedBy).Not.Nullable().Length(35);
            Map(x => x.LastModifiedBy).Nullable().Length(35);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("TeamListEmployees");
        }
    }
}
