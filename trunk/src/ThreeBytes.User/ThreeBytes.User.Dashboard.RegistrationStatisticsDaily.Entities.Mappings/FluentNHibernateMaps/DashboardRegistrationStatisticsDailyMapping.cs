using FluentNHibernate.Mapping;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Entities;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Entities.Mappings.FluentNHibernateMaps
{
    public class DashboardRegistrationStatisticsDailyMapping : ClassMap<DashboardRegistrationStatisticsDaily>
    {
        public DashboardRegistrationStatisticsDailyMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("DailyRegistrationId");

            Map(x => x.UserId).Not.Nullable();
            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.RegistrationDateTime).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("DashboardDailyRegistrations");
        }
    }
}
