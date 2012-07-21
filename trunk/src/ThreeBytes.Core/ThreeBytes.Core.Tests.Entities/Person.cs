using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.Core.Tests.Entities
{
    public class Person : BusinessObject<Person>, IBusinessObject<Person>
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
