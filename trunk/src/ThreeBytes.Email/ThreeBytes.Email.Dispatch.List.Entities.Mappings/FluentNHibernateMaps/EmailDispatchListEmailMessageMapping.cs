using FluentNHibernate.Mapping;

namespace ThreeBytes.Email.Dispatch.List.Entities.Mappings.FluentNHibernateMaps
{
    public class EmailDispatchListEmailMessageMapping : ClassMap<EmailDispatchListEmailMessage>
    {
        public EmailDispatchListEmailMessageMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("EmailMessageId");

            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.From).Column("[From]").Not.Nullable().Length(128);
            Map(x => x.To).Column("[To]").Not.Nullable().Length(128);
            Map(x => x.CC);
            Map(x => x.BCC);
            Map(x => x.Subject).Not.Nullable().Length(255);
            Map(x => x.IsHtml).Not.Nullable();
            Map(x => x.Encoding).Not.Nullable().Length(16);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("EmailDispatchListEmailMessage");
        }
    }
}
