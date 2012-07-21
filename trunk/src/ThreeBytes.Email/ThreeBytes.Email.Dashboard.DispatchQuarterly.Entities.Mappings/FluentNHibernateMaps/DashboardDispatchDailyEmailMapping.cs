using FluentNHibernate.Mapping;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Entities;

namespace ThreeBytes.Email.Dispatch.Widget.Entities.Mappings.FluentNHibernateMaps
{
    public class DashboardDispatchDailyEmailMapping : ClassMap<DashboardDispatchQuarterlyEmail>
    {
        public DashboardDispatchDailyEmailMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("QuarterlyEmailId");

            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.To).Column("[To]").Not.Nullable().Length(128);
            Map(x => x.Subject).Not.Nullable().Length(255);
            Map(x => x.Quarter).Not.Nullable();
            Map(x => x.Year).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("DashboardDispatchQuarterlyEmails");
        }
    }
}
