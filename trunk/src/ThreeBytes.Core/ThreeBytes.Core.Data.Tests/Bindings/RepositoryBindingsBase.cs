using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.MappingModel;
using NUnit.Framework;
using TechTalk.SpecFlow;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Core.Data.Concrete;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Data.Tests.Helpers;
using ThreeBytes.Core.Extensions.String;
using ThreeBytes.Core.Tests.Entities;
using ThreeBytes.Core.Tests.Helpers;

using TechTalk.SpecFlow.Assist;
using ThreeBytes.Core.Tests.Infrastructure;

namespace ThreeBytes.Core.Data.Tests.Bindings
{
    [Binding]
    public class RepositoryBindingsBase
    {
        protected IReadOnlyGenericRepository<Person> _readOnlyRepository;
        protected IGenericRepository<Person> _genericRepository;
        protected IKeyedGenericRepository<Person> _keyedRepository;

        [AfterScenario]
        public void TearDown()
        {
            if (_readOnlyRepository != null)
                _readOnlyRepository.Dispose();

            if (_genericRepository != null)
                _genericRepository.Dispose();

            if (_keyedRepository != null)
                _keyedRepository.Dispose();
        }

        [Given(@"I have created a person (.*) repository")]
        public void GivenIHaveCreatedAPersonReadOnlyGenericRepository(string repository)
        {
            switch (repository.StripQuotations())
            {
                case "read only":
                    _readOnlyRepository = new ReadOnlyGenericRepository<Person>(new SQLiteInMemoryDatabaseFactory());
                    break;
                case "generic":
                    _genericRepository = new GenericRepository<Person>(new SQLiteInMemoryDatabaseFactory(), new UnitOfWork(new SQLiteInMemoryDatabaseFactory()));
                    break;
                case "keyed":
                    _keyedRepository = new KeyedGenericRepository<Person>(new SQLiteInMemoryDatabaseFactory(), new UnitOfWork(new SQLiteInMemoryDatabaseFactory()));
                    break;
            }
        }

        [Given(@"I have saved the following person using the (.*) repository")]
        public void GivenIHaveSavedTheFollowingPersonUsingTheGenericRepository(string repository, Table table)
        {
            Person person = table.CreateInstance<Person>();

            switch (repository.StripQuotations())
            {
                case "read only":
                    InsertDataHelper.InsertPerson(person);
                    break;
                case "generic":
                    _genericRepository.UnitOfWork.BeginTransaction();
                    _genericRepository.Add(person);
                    _genericRepository.UnitOfWork.CommitTransaction();
                    break;
                case "keyed":
                    _keyedRepository.UnitOfWork.BeginTransaction();
                    _keyedRepository.Add(person);
                    _keyedRepository.UnitOfWork.CommitTransaction();
                    break;
            }
        }


        [Given(@"I have saved the following people using the (.*) repository")]
        public void GivenIHaveSavedTheFollowingPeople(string repository, Table table)
        {
            IEnumerable<Person> people = table.CreateSet<Person>();

            switch (repository.StripQuotations())
            {
                case "read only":
                    InsertDataHelper.InsertPeople(people);
                    break;
                case "generic":
                    _genericRepository.UnitOfWork.BeginTransaction();
                    _genericRepository.Add(people);
                    _genericRepository.UnitOfWork.CommitTransaction();
                    break;
                case "keyed":
                    _keyedRepository.UnitOfWork.BeginTransaction();
                    _keyedRepository.Add(people);
                    _keyedRepository.UnitOfWork.CommitTransaction();
                    break;
            }
        }

        [When(@"I select all records using the (.*) repository")]
        public void WhenISelectAllRecords(string repository)
        {
            switch (repository.StripQuotations())
            {
                case "read only":
                    ScenarioContextManager.Set("result", _readOnlyRepository.GetAll());
                    break;
                case "generic":
                    ScenarioContextManager.Set("result", _genericRepository.GetAll());
                    break;
                case "keyed":
                    ScenarioContextManager.Set("result", _keyedRepository.GetAll());
                    break;
            }
        }

        [When(@"I select all records paged with a page size of (.*) using the (.*) repository")]
        public void WhenISelectAllRecordsPagedWithAPageSizeOfUsingTheReadOnlyRepository(string pageSize, string repository)
        {
            switch (repository.StripQuotations())
            {
                case "read only":
                    ScenarioContextManager.Set("result", _readOnlyRepository.GetAllPaged(int.Parse(pageSize), null));
                    break;
                case "generic":
                    ScenarioContextManager.Set("result", _genericRepository.GetAllPaged(int.Parse(pageSize), null));
                    break;
                case "keyed":
                    ScenarioContextManager.Set("result", _keyedRepository.GetAllPaged(int.Parse(pageSize), null));
                    break;
            }
        }

        [When(@"I select a record with (.*) as its ID")]
        public void WhenISelectARecordByID(string id)
        {
            ScenarioContextManager.Set("result", _keyedRepository.GetById(Guid.Parse(id)));
        }

        [When(@"I delete the following person using the (.*) repository")]
        public void WhenIDeleteTheFollowingPersonUsingTheGenericRepository(string repository, Table table)
        {
            Person tableObject = table.CreateInstance<Person>();

            Person person = getPersonUsingFirstAndLastNames(repository, tableObject.FirstName, tableObject.LastName);

            switch (repository.StripQuotations())
            {
                case "generic":
                    _genericRepository.UnitOfWork.BeginTransaction();
                    _genericRepository.Delete(person);
                    _genericRepository.UnitOfWork.CommitTransaction();
                    ScenarioContextManager.Set("result", _genericRepository.GetAll());
                    break;
                case "keyed":
                    _keyedRepository.UnitOfWork.BeginTransaction();
                    _keyedRepository.Delete(person);
                    _keyedRepository.UnitOfWork.CommitTransaction();
                    ScenarioContextManager.Set("result", _keyedRepository.GetAll());
                    break;
            }
        }

        [When(@"I delete the following people using the (.*) repository")]
        public void WhenIDeleteTheFollowingPeopleUsingTheGenericRepository(string repository, Table table)
        {
            IEnumerable<Person> tableObjects = table.CreateSet<Person>();

            IList<Person> people = tableObjects.Select(person => getPersonUsingFirstAndLastNames(repository, person.FirstName, person.LastName)).Where(p => p != null).ToList();

            switch (repository.StripQuotations())
            {
                case "generic":
                    _genericRepository.UnitOfWork.BeginTransaction();
                    _genericRepository.Delete(people);
                    _genericRepository.UnitOfWork.CommitTransaction();
                    ScenarioContextManager.Set("result", _genericRepository.GetAll());
                    break;
                case "keyed":
                    _keyedRepository.UnitOfWork.BeginTransaction();
                    _keyedRepository.Delete(people);
                    _keyedRepository.UnitOfWork.CommitTransaction();
                    ScenarioContextManager.Set("result", _keyedRepository.GetAll());
                    break;
            }
        }

        [When(@"I filter all records by last name of (.*) using the (.*) repository")]
        public void WhenIFilterAllRecordsByLastNameOfSaundersUsingTheReadOnlyRepository(string lastname, string repository)
        {
            switch (repository.StripQuotations())
            {
                case "read only":
                    ScenarioContextManager.Set("result", _readOnlyRepository.FilterBy(x => x.LastName == lastname));
                    break;
                case "generic":
                    ScenarioContextManager.Set("result", _genericRepository.FilterBy(x => x.LastName == lastname));
                    break;
                case "keyed":
                    ScenarioContextManager.Set("result", _keyedRepository.FilterBy(x => x.LastName == lastname));
                    break;
            }
        }

        [When(@"I update the record (.*), (.*) using the (.*) repository to:")]
        public void WhenIUpdateTheRecordUsingTheRepositoryTo(string firstName, string lastName, string repository, Table table)
        {
            Person tableObject = table.CreateInstance<Person>();
            Person updateable = updatePerson(getPersonUsingFirstAndLastNames(repository, firstName, lastName), tableObject);

            switch (repository.StripQuotations())
            {
                case "generic":
                    ScenarioContextManager.Set("result", _genericRepository.Update(updateable));
                    break;
                case "keyed":
                    ScenarioContextManager.Set("result", _keyedRepository.Update(updateable));
                    break;
            }
        }

        [Then(@"the single result should contain (.*) as a first name")]
        public void ThenTheSingleResultShouldContainJonathanAsItsFirstName(string firstname)
        {
            Person result = ScenarioContextManager.Get<Person>("result");

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result.FirstName, Is.EqualTo(firstname.StripQuotations()));
        }

        [Then(@"the single result should contain (.*) as a surname")]
        public void ThenTheSingleResultShouldContainJonathanAsItsSurname(string surname)
        {
            Person result = ScenarioContextManager.Get<Person>("result");

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result.LastName, Is.EqualTo(surname.StripQuotations()));
        }

        [Then(@"the result set should contain (.*) records")]
        public void ThenTheResultShouldContain1Record(string count)
        {
            IList<Person> result = ScenarioContextManager.Get<List<Person>>("result");
            Assert.That(result.Count, Is.EqualTo(int.Parse(count.StripQuotations())));
        }

        [Then(@"the result set should contain (.*) as a first name")]
        public void ThenTheResultShouldContainJonathanAsItsFirstName(string firstname)
        {
            IList<Person> resultSet = ScenarioContextManager.Get<List<Person>>("result");

            IList<Person> result = resultSet.Where(x => x.FirstName == firstname.StripQuotations()).ToList();

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Then(@"the result set should contain (.*) as a surname")]
        public void ThenTheResultShouldContainJonathanAsItsSurname(string surname)
        {
            IList<Person> resultSet = ScenarioContextManager.Get<List<Person>>("result");

            IList<Person> result = resultSet.Where(x => x.LastName == surname.StripQuotations()).ToList();

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Then(@"the result set should not contain (.*) as a first name (.*) as a surname")]
        public void ThenTheResultShouldNotContainSaundersAsItsSurname(string firstname, string surname)
        {
            IList<Person> resultSet = ScenarioContextManager.Get<List<Person>>("result");

            IList<Person> result = resultSet.Where(x => x.FirstName == firstname && x.LastName == surname.StripQuotations()).ToList();

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Then(@"the result set should contain (.*) pages")]
        public void ThenTheResultSetShouldContainPages(string numberOfPages)
        {
            IPagedResult<Person> result = ScenarioContextManager.Get<PagedResult<Person>>("result");

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result.PageCount, Is.EqualTo(int.Parse(numberOfPages)));
        }

        [Then(@"the result set should contain (.*) paged items")]
        public void ThenTheResultSetShouldContainPagedItems(string pagedItems)
        {
            IPagedResult<Person> result = ScenarioContextManager.Get<PagedResult<Person>>("result");

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result.Items.Count(), Is.EqualTo(int.Parse(pagedItems)));
        }

        [Then(@"the result set should contain (.*) new items")]
        public void ThenTheResultSetShouldContainNewItems(string newItems)
        {
            IPagedResult<Person> result = ScenarioContextManager.Get<PagedResult<Person>>("result");

            Assert.That(result, Is.Not.EqualTo(null));
        }

        [Then(@"the result set should contain (.*) total items")]
        public void ThenTheResultSetShouldContainTotalItems(string totalItems)
        {
            IPagedResult<Person> result = ScenarioContextManager.Get<PagedResult<Person>>("result");

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result.TotalItemCount, Is.EqualTo(int.Parse(totalItems)));
        }

        [Then(@"the result set should contain the page number of (.*)")]
        public void ThenTheResultSetShouldContainThePageNumberOf(string pageNumber)
        {
            IPagedResult<Person> result = ScenarioContextManager.Get<PagedResult<Person>>("result");

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result.PageNumber, Is.EqualTo(int.Parse(pageNumber)));
        }

        [Then(@"the result set should contain the page size of (.*)")]
        public void ThenTheResultSetShouldContainThePageSizeOf(string pageSize)
        {
            IPagedResult<Person> result = ScenarioContextManager.Get<PagedResult<Person>>("result");

            Assert.That(result, Is.Not.EqualTo(null));
            Assert.That(result.PageSize, Is.EqualTo(int.Parse(pageSize)));
        }

        [Then(@"the result set (should|should not) contain a previous page")]
        public void ThenTheResultSetShouldNotContainAPreviousPage(string condition)
        {
            IPagedResult<Person> result = ScenarioContextManager.Get<PagedResult<Person>>("result");

            Assert.That(result, Is.Not.EqualTo(null));

            switch (condition)
            {
                case "should":
                    Assert.That(result.HasPreviousPage, Is.EqualTo(true));
                    break;
                case "should not":
                    Assert.That(result.HasPreviousPage, Is.EqualTo(false));
                    break;
            }
        }

        [Then(@"the result set (should|should not) contain a next page")]
        public void ThenTheResultSetShouldContainANextPage(string condition)
        {
            IPagedResult<Person> result = ScenarioContextManager.Get<PagedResult<Person>>("result");

            Assert.That(result, Is.Not.EqualTo(null));

            switch (condition)
            {
                case "should":
                    Assert.That(result.HasNextPage, Is.EqualTo(true));
                    break;
                case "should not":
                    Assert.That(result.HasNextPage, Is.EqualTo(false));
                    break;
            }
        }

        [Then(@"the result set (should|should not) be the first page")]
        public void ThenTheResultSetShouldBeTheFirstPage(string condition)
        {
            IPagedResult<Person> result = ScenarioContextManager.Get<PagedResult<Person>>("result");

            Assert.That(result, Is.Not.EqualTo(null));

            switch (condition)
            {
                case "should":
                    Assert.That(result.IsFirstPage, Is.EqualTo(true));
                    break;
                case "should not":
                    Assert.That(result.IsFirstPage, Is.EqualTo(false));
                    break;
            }
        }

        [Then(@"the result set (should|should not) be the last page")]
        public void ThenTheResultSetShouldNotBeTheLastPage(string condition)
        {
            IPagedResult<Person> result = ScenarioContextManager.Get<PagedResult<Person>>("result");

            Assert.That(result, Is.Not.EqualTo(null));

            switch (condition)
            {
                case "should":
                    Assert.That(result.IsLastPage, Is.EqualTo(true));
                    break;
                case "should not":
                    Assert.That(result.IsLastPage, Is.EqualTo(false));
                    break;
            }
        }

        [Then(@"the result should be (true|false)")]
        public void ThenTheResultShouldBe(string condition)
        {
            bool result = ScenarioContextManager.Get<bool>("result");
            Assert.That(result, Is.EqualTo(bool.Parse(condition)));
        }

        [Then(@"when I query for (.*), (.*) with the (.*) repository they will (exist|not exist)")]
        public void ThenWhenIQueryForTheyWill(string firstName, string lastName, string repository, string condition)
        {
            Person person = getPersonUsingLastName(repository, lastName);

            Assert.That(person, Is.Not.EqualTo(null));
            Assert.That(person.FirstName, Is.EqualTo(firstName));
            Assert.That(person.LastName, Is.EqualTo(lastName));
        }

        private Person getPersonUsingLastName(string repository, string lastname)
        {
            Person person = new Person();

            switch (repository.StripQuotations())
            {
                case "generic":
                    person = _genericRepository.FindBy(x => x.LastName == lastname);
                    break;
                case "keyed":
                    person = _keyedRepository.FindBy(x => x.LastName == lastname);
                    break;
            }

            return person;
        }

        private Person getPersonUsingFirstAndLastNames(string repository, string firstname, string lastname)
        {
            Person person = new Person();

            switch (repository.StripQuotations())
            {
                case "generic":
                    person = _genericRepository.FindBy(x => x.FirstName == firstname && x.LastName == lastname);
                    break;
                case "keyed":
                    person = _keyedRepository.FindBy(x => x.FirstName == firstname && x.LastName == lastname);
                    break;
            }

            return person;
        }

        private Person updatePerson(Person original, Person updateTo)
        {
            original.FirstName = updateTo.FirstName;
            original.LastName = updateTo.LastName;

            return original;
        }
    }
}
