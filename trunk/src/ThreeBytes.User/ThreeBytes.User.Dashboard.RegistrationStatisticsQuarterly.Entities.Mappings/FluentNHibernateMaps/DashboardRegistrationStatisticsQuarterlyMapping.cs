using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Entities.Mappings.FluentNHibernateMaps
{
    public class DashboardRegistrationStatisticsQuarterlyMapping : ClassMap<DashboardRegistrationStatisticsQuarterly>
    {
        public DashboardRegistrationStatisticsQuarterlyMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("QuarterlyRegistrationId");

            Map(x => x.UserId).Not.Nullable();
            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.Quarter).Not.Nullable();
            Map(x => x.Year).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("DashboardQuarterlyRegistrations");
        }
    }
}
