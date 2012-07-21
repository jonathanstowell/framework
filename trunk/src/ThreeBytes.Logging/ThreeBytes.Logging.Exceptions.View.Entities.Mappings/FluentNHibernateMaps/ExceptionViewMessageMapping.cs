using FluentNHibernate.Mapping;

namespace ThreeBytes.Logging.Exceptions.View.Entities.Mappings.FluentNHibernateMaps
{
    public class ExceptionViewMessageMapping : ClassMap<ExceptionView>
    {
        public ExceptionViewMessageMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("ExceptionId");

            Map(x => x.Message).Not.Nullable();
            Map(x => x.Source).Not.Nullable();
            Map(x => x.StackTrace).Not.Nullable();
            Map(x => x.InnerException);

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("ExceptionView");
        }
    }
}
