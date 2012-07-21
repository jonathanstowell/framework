using FluentNHibernate.Mapping;

namespace ThreeBytes.ProjectHollywood.Team.Management.Entities.Mappings.FluentNHibernateMaps
{
    public class TeamManagementEmployeeMapping : ClassMap<TeamManagementEmployee>
    {
        public TeamManagementEmployeeMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("EmployeeId");

            Map(x => x.FirstName).Length(35).Not.Nullable();
            Map(x => x.LastName).Length(35).Not.Nullable();
            Map(x => x.JobTitle).Length(50).Not.Nullable();
            Map(x => x.ProfileImageLocation).Nullable();
            Map(x => x.ProfileThumbnailImageLocation).Nullable();
            Map(x => x.Summary).Nullable();

            Map(x => x.CreatedBy).Not.Nullable().Length(35);
            Map(x => x.LastModifiedBy).Nullable().Length(35);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("TeamManagementEmployees");
        }
    }
}
