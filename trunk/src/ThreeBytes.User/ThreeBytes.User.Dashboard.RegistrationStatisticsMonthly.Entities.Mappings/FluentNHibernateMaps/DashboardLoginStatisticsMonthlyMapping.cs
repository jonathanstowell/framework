using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Entities.Mappings.FluentNHibernateMaps
{
    public class DashboardLoginStatisticsMonthlyMapping : ClassMap<DashboardRegistrationStatisticsMonthly>
    {
        public DashboardLoginStatisticsMonthlyMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("MonthlyRegistrationId");

            Map(x => x.UserId).Not.Nullable();
            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.Month).Not.Nullable();
            Map(x => x.Year).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("DashboardMonthlyRegistrations");
        }
    }
}
