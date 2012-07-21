using FluentNHibernate.Mapping;

namespace ThreeBytes.Email.Template.Widget.Entities.Mappings.FluentNHibernateMaps
{
    public class EmailTemplateWidgetTemplateMapping : ClassMap<EmailTemplateWidgetTemplate>
    {
        public EmailTemplateWidgetTemplateMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("TemplateId");

            Map(x => x.Name).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.Subject).Not.Nullable().Length(255);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("EmailTemplateWidgetTemplate");
        }
    }
}
