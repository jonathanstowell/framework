using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Data.ResultSets.Concrete;
using ThreeBytes.Core.Extensions.String;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Core.Tests.Entities;
using ThreeBytes.Core.Tests.Helpers;

namespace ThreeBytes.Core.Service.Tests.Bindings
{
    [Binding]
    public class ServiceBindingsBase
    {
        protected IReadOnlyGenericService<Person> _readOnlyService;
        protected IGenericService<Person> _genericService;
        protected IKeyedGenericService<Person> _keyedService;

        [Given(@"I have created a person (.*) service")]
        public void GivenIHaveCreatedAPersonReadOnlyGenericRepository(string service)
        {
            switch (service.StripQuotations())
            {
                case "read only":
                    _readOnlyService = null;
                    break;
                case "generic":
                    _genericService = null;
                    break;
                case "keyed":
                    _keyedService = null;
                    break;
            }
        }

        [Given(@"I have saved the following person using the (.*) service")]
        public void GivenIHaveSavedTheFollowingPersonUsingTheGenericRepository(string service, Table table)
        {
            Person person = table.CreateInstance<Person>();

            switch (service.StripQuotations())
            {
                case "generic":
                    _genericService.Create(person);
                    break;
                case "keyed":
                    _keyedService.Create(person);
                    break;
            }
        }


        [Given(@"I have saved the following people using the (.*) service")]
        public void GivenIHaveSavedTheFollowingPeople(string service, Table table)
        {
            IEnumerable<Person> people = table.CreateSet<Person>();

            switch (service.StripQuotations())
            {
                case "generic":
                    _genericService.Create(people);
                    break;
                case "keyed":
                    _keyedService.Create(people);
                    break;
            }
        }

        [When(@"I select all records using the (.*) service")]
        public void WhenISelectAllRecords(string service)
        {
            switch (service.StripQuotations())
            {
                case "read only":
                    ScenarioContextManager.Set("result", _readOnlyService.GetAll());
                    break;
                case "generic":
                    ScenarioContextManager.Set("result", _genericService.GetAll());
                    break;
                case "keyed":
                    ScenarioContextManager.Set("result", _keyedService.GetAll());
                    break;
            }
        }

        [When(@"I select all records paged with a page size of (.*) using the (.*) service")]
        public void WhenISelectAllRecordsPagedWithAPageSizeOfUsingTheReadOnlyRepository(string pageSize, string service)
        {
            switch (service.StripQuotations())
            {
                case "read only":
                    ScenarioContextManager.Set("result", _keyedService.GetAllPaged(int.Parse(pageSize), null));
                    break;
                case "generic":
                    ScenarioContextManager.Set("result", _genericService.GetAllPaged(int.Parse(pageSize), null));
                    break;
                case "keyed":
                    ScenarioContextManager.Set("result", _keyedService.GetAllPaged(int.Parse(pageSize), null));
                    break;
            }
        }

        [When(@"I select a record with (.*) as its ID")]
        public void WhenISelectARecordByID(string id)
        {
            ScenarioContextManager.Set("result", _keyedService.GetById(Guid.Parse(id)));
        }

        [When(@"I delete the following person using the (.*) service")]
        public void WhenIDeleteTheFollowingPersonUsingTheGenericRepository(string service, Table table)
        {
            Person tableObject = table.CreateInstance<Person>();

            Person person = getPersonUsingFirstAndLastNames(service, tableObject.FirstName, tableObject.LastName);

            switch (service.StripQuotations())
            {
                case "generic":
                    _genericService.Delete(person);
                    ScenarioContextManager.Set("result", _genericService.GetAll());
                    break;
                case "keyed":
                    _keyedService.Delete(person);
                    ScenarioContextManager.Set("result", _keyedService.GetAll());
                    break;
            }
        }

        [When(@"I delete the following people using the (.*) service")]
        public void WhenIDeleteTheFollowingPeopleUsingTheGenericRepository(string service, Table table)
        {
            IEnumerable<Person> tableObjects = table.CreateSet<Person>();

            IList<Person> people = tableObjects.Select(person => getPersonUsingFirstAndLastNames(service, person.FirstName, person.LastName)).Where(p => p != null).ToList();

            switch (service.StripQuotations())
            {
                case "generic":
                    _genericService.Delete(people);
                    ScenarioContextManager.Set("result", _keyedService.GetAll());
                    break;
                case "keyed":
                    _keyedService.Delete(people);
                    ScenarioContextManager.Set("result", _keyedService.GetAll());
                    break;
            }
        }

        [When(@"I filter all records by last name of (.*) using the (.*) service")]
        public void WhenIFilterAllRecordsByLastNameOfSaundersUsingTheReadOnlyRepository(string lastname, string service)
        {
            switch (service.StripQuotations())
            {
                case "read only":
                    ScenarioContextManager.Set("result", _readOnlyService.FilterBy(x => x.LastName == lastname));
                    break;
                case "generic":
                    ScenarioContextManager.Set("result", _genericService.FilterBy(x => x.LastName == lastname));
                    break;
                case "keyed":
                    ScenarioContextManager.Set("result", _keyedService.FilterBy(x => x.LastName == lastname));
                    break;
            }
        }

        [When(@"I update the record (.*), (.*) using the (.*) service to:")]
        public void WhenIUpdateTheRecordUsingTheRepositoryTo(string firstName, string lastName, string service, Table table)
        {
            Person tableObject = table.CreateInstance<Person>();
            Person updateable = updatePerson(getPersonUsingFirstAndLastNames(service, firstName, lastName), tableObject);

            switch (service.StripQuotations())
            {
                case "generic":
                    ScenarioContextManager.Set("result", _genericService.Update(updateable));
                    break;
                case "keyed":
                    ScenarioContextManager.Set("result", _keyedService.Update(updateable));
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

        [Then(@"when I query for (.*), (.*) with the (.*) Repository they will (exist|not exist)")]
        public void ThenWhenIQueryForTheyWill(string firstName, string lastName, string repository, string condition)
        {
            Person person = getPersonUsingLastName(repository, lastName);

            Assert.That(person, Is.Not.EqualTo(null));
            Assert.That(person.FirstName, Is.EqualTo(firstName));
            Assert.That(person.LastName, Is.EqualTo(lastName));
        }

        private Person getPersonUsingLastName(string service, string lastname)
        {
            Person person = new Person();

            switch (service.StripQuotations())
            {
                case "generic":
                    person = _genericService.FindBy(x => x.LastName == lastname);
                    break;
                case "keyed":
                    person = _keyedService.FindBy(x => x.LastName == lastname);
                    break;
            }

            return person;
        }

        private Person getPersonUsingFirstAndLastNames(string service, string firstname, string lastname)
        {
            Person person = new Person();

            switch (service.StripQuotations())
            {
                case "generic":
                    person = _genericService.FindBy(x => x.FirstName == firstname && x.LastName == lastname);
                    break;
                case "keyed":
                    person = _keyedService.FindBy(x => x.FirstName == firstname && x.LastName == lastname);
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
