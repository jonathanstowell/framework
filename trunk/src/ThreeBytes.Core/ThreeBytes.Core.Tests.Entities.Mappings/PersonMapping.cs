using FluentNHibernate.Mapping;

namespace ThreeBytes.Core.Tests.Entities.Mappings
{
    public class PersonMapping : ClassMap<Person>
    {
        public PersonMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.CreationDateTime);
            Map(x => x.LastModifiedDateTime).Nullable();
            Map(x => x.FirstName);
            Map(x => x.LastName);

            Table("Person");
        }
    }
}
