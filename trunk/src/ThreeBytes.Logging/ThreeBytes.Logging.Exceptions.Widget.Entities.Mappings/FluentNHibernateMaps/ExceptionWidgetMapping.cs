using FluentNHibernate.Mapping;

namespace ThreeBytes.Logging.Exceptions.Widget.Entities.Mappings.FluentNHibernateMaps
{
    public class ExceptionWidgetMapping : ClassMap<ExceptionWidget>
    {
        public ExceptionWidgetMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("ExceptionId");

            Map(x => x.Message).Not.Nullable();
            Map(x => x.Source).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("ExceptionWidget");
        }
    }
}
