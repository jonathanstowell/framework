using FluentNHibernate.Mapping;

namespace ThreeBytes.Email.Template.List.Entities.Mappings.FluentNHibernateMaps
{
    public class EmailTemplateListTemplateMapping : ClassMap<EmailTemplateListTemplate>
    {
        public EmailTemplateListTemplateMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("TemplateId");

            Map(x => x.Name).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.From).Column("[From]").Not.Nullable().Length(128);
            Map(x => x.Subject).Not.Nullable().Length(255);
            Map(x => x.IsHtml).Not.Nullable();
            Map(x => x.Encoding).Not.Nullable().Length(16);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("EmailTemplateListTemplate");
        }
    }
}
