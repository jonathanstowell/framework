using FluentNHibernate.Mapping;

namespace ThreeBytes.Email.Dashboard.DispatchDaily.Entities.Mappings.FluentNHibernateMaps
{
    public class DashboardDispatchDailyEmailMapping : ClassMap<DashboardDispatchDailyEmail>
    {
        public DashboardDispatchDailyEmailMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("DailyEmailId");

            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.To).Column("[To]").Not.Nullable().Length(128);
            Map(x => x.Subject).Not.Nullable().Length(255);
            Map(x => x.DispatchDate).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("DashboardDispatchDailyEmails");
        }
    }
}
