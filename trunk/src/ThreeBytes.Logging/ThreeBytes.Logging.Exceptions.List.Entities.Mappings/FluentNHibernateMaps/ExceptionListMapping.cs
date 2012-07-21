using FluentNHibernate.Mapping;

namespace ThreeBytes.Logging.Exceptions.List.Entities.Mappings.FluentNHibernateMaps
{
    public class ExceptionListMapping : ClassMap<ExceptionList>
    {
        public ExceptionListMapping()
        {
            Id(x => x.Id).GeneratedBy.Assigned().Column("ExceptionId");

            Map(x => x.Message).Not.Nullable();
            Map(x => x.Source).Not.Nullable();

            Map(x => x.CreationDateTime).Not.Nullable();
            Map(x => x.LastModifiedDateTime).Nullable();

            Table("ExceptionList");
        }
    }
}
