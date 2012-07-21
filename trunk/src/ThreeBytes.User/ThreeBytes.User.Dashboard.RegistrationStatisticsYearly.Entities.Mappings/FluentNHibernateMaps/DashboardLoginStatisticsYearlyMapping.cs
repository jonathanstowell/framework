using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Entities.Mappings.FluentNHibernateMaps
{
    public class DashboardLoginStatisticsYearlyMapping : ClassMap<DashboardRegistrationStatisticsYearly>
    {
        public DashboardLoginStatisticsYearlyMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("YearlyRegistrationId");

            Map(x => x.UserId).Not.Nullable();
            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.Year).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("DashboardYearlyRegistrations");
        }
    }
}
