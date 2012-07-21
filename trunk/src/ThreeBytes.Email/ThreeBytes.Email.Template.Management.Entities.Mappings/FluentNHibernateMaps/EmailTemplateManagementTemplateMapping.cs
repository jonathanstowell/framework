using FluentNHibernate.Mapping;

namespace ThreeBytes.Email.Template.Management.Entities.Mappings.FluentNHibernateMaps
{
    public class EmailTemplateManagementTemplateMapping : ClassMap<EmailTemplateManagementTemplate>
    {
        public EmailTemplateManagementTemplateMapping()
        {
            Id(x => x.Id).GeneratedBy.GuidComb().Column("TemplateId");

            Map(x => x.Name).Not.Nullable().Length(64);
            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.From).Column("[From]").Not.Nullable().Length(128);
            Map(x => x.Subject).Not.Nullable().Length(255);
            Map(x => x.Body).Not.Nullable();
            Map(x => x.IsHtml).Not.Nullable();
            Map(x => x.Encoding).Not.Nullable().Length(16);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("EmailTemplateManagementTemplate");
        }
    }
}
