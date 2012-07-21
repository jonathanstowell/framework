using FluentNHibernate.Mapping;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Entities.Mappings.FluentNHibernateMaps
{
    public class DashboardDispatchYearlyEmailMapping : ClassMap<DashboardDispatchYearlyEmail>
    {
        public DashboardDispatchYearlyEmailMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("YearlyEmailId");

            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.To).Column("[To]").Not.Nullable().Length(128);
            Map(x => x.Subject).Not.Nullable().Length(255);
            Map(x => x.Year).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("DashboardDispatchYearlyEmails");
        }
    }
}
