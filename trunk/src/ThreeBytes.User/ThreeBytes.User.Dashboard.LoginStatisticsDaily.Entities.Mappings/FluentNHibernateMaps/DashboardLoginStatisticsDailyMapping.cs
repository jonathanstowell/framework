using FluentNHibernate.Mapping;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Entities.Mappings.FluentNHibernateMaps
{
    public class DashboardLoginStatisticsDailyMapping : ClassMap<DashboardLoginStatisticsDaily>
    {
        public DashboardLoginStatisticsDailyMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("DailyLoginId");

            Map(x => x.UserId).Not.Nullable();
            Map(x => x.Username).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.LoginDate).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("DashboardDailyLogins");
        }
    }
}
