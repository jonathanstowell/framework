using FluentNHibernate.Mapping;

namespace ThreeBytes.Email.Dispatch.Widget.Entities.Mappings.FluentNHibernateMaps
{
    public class EmailDispatchWidgetEmailMessageMapping : ClassMap<EmailDispatchWidgetEmailMessage>
    {
        public EmailDispatchWidgetEmailMessageMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("EmailMessageId");

            Map(x => x.ApplicationName).Not.Nullable().Length(64);
            Map(x => x.To).Column("[To]").Not.Nullable().Length(128);
            Map(x => x.Subject).Not.Nullable().Length(255);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("EmailDispatchWidgetEmailMessage");
        }
    }
}
