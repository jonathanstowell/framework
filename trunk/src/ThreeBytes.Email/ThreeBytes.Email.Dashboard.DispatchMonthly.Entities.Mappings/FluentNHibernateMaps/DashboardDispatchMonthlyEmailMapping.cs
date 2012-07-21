using FluentNHibernate.Mapping;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Entities.Mappings.FluentNHibernateMaps
{
    public class DashboardDispatchMonthlyEmailMapping : ClassMap<DashboardDispatchMonthlyEmail>
    {
        public DashboardDispatchMonthlyEmailMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("MonthlyEmailId");

            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.To).Column("[To]").Not.Nullable().Length(128);
            Map(x => x.Subject).Not.Nullable().Length(255);
            Map(x => x.Month).Not.Nullable();
            Map(x => x.Year).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("DashboardDispatchMonthlyEmails");
        }
    }
}
