using System.Collections.Generic;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.Concrete;
using ThreeBytes.Core.Tests.Entities;
using ThreeBytes.Core.Tests.Infrastructure;

namespace ThreeBytes.Core.Data.Tests.Helpers
{
    public static class InsertDataHelper
    {
        private static IGenericRepository<Person> _genericRepository = new GenericRepository<Person>(new SQLiteInMemoryDatabaseFactory(), new UnitOfWork(new SQLiteInMemoryDatabaseFactory()));

        public static void InsertPerson(Person person)
        {
            _genericRepository.UnitOfWork.BeginTransaction();
            _genericRepository.Add(person);
            _genericRepository.UnitOfWork.CommitTransaction();
        }

        public static void InsertPeople(IEnumerable<Person> people)
        {
            _genericRepository.UnitOfWork.BeginTransaction();
            _genericRepository.Add(people);
            _genericRepository.UnitOfWork.CommitTransaction();
        }
    }
}
