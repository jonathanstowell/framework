using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ThreeBytes.Core.Tests.Helpers;
using ThreeBytes.ProjectHollywood.News.List.Data.Abstract;
using ThreeBytes.ProjectHollywood.News.List.Data.Concrete;
using ThreeBytes.ProjectHollywood.News.List.Data.Concrete.Infrastructure;
using ThreeBytes.ProjectHollywood.News.List.Entities;
using ThreeBytes.ProjectHollywood.News.List.Tests.Shared;

namespace ThreeBytes.ProjectHollywood.News.List.Data.Tests.Bindings
{
    [Binding]
    public class NewsListDataBindings
    {
        private INewsListNewsArticleRepository repository;

        [BeforeScenario]
        public void Setup()
        {
            var databaseFactory = new NewsListInMemoryDatabaseFactory(new ProvideInMemoryNewsListSessionFactoryInitialisation());

            repository =
                    new NewsListArticleRepository(
                        databaseFactory,
                        new NewsListUnitOfWork(databaseFactory));
        }

        [AfterScenario]
        public void TearDown()
        {
            repository = null;
        }

        [Given(@"I have a news list article with the properties")]
        public void NewsListArticleWithProperties(Table table)
        {
            NewsListNewsArticle item = table.CreateInstance<NewsListNewsArticle>();

            if (string.Equals(item.CreatedBy, "null"))
                item.CreatedBy = null;
            if (string.Equals(item.Title, "null"))
                item.Title = null;
            if (string.Equals(item.Content, "null"))
                item.Content = null;

            ScenarioContextManager.Set("newsArticle", item);
        }

        [Given(@"I have a saved news list article with the properties")]
        public void SavedNewsManagementArticleWithProperties(Table table)
        {
            NewsListNewsArticle item = table.CreateInstance<NewsListNewsArticle>();

            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();

            repository.UnitOfWork.BeginTransaction();
            repository.Add(item);
            repository.UnitOfWork.CommitTransaction();

            ScenarioContextManager.Set("newsArticleIdentifier", item.Id);
        }

        [Given(@"I have a null news list article")]
        public void NullNewsManagementArticle()
        {
            NewsListNewsArticle item = null;
            ScenarioContextManager.Set("newsArticle", item);
        }

        [When(@"I attempt to (.*) the article in a transaction")]
        public void PerformDataOperationOnArticleInATransaction(string action)
        {
            bool? repositoryResult = null;

            NewsListNewsArticle item = GetNewsManagementNewsArticleTestObject();

            repository.UnitOfWork.BeginTransaction();

            if (action == "create")
            {
                repositoryResult = repository.Add(item);
                ScenarioContextManager.Set("newsArticleIdentifier", item.Id);
            }
            else if (action == "delete")
            {
                repositoryResult = repository.Delete(item);
            }

            repository.UnitOfWork.CommitTransaction();

            ScenarioContextManager.Set("repositoryResult", repositoryResult);
        }

        [When(@"I delete the news list article with the id (.*) in a transaction")]
        public void PerformDeleteDataOperationOnArticleInATransaction(string id)
        {
            NewsListNewsArticle item = GetNewsManagementNewsArticleTestObject(Guid.Parse(id));

            repository.UnitOfWork.BeginTransaction();
            repository.Delete(item);
            repository.UnitOfWork.CommitTransaction();

            ScenarioContextManager.Set("newsArticleIdentifier", item.Id);
        }

        [When(@"I attempt to (.*) the article not in a transaction")]
        public void PerformDataOperationOnArticleNotInATransaction(string action)
        {
            bool? repositoryResult = null;

            if (action == "create")
                repositoryResult = repository.Add(ScenarioContextManager.Get<NewsListNewsArticle>("newsArticle"));

            ScenarioContextManager.Set("repositoryResult", repositoryResult);
        }

        [When(@"I update the news list article to the values below in a transaction")]
        public void UpdateTheValuesInATransaction(Table table)
        {
            NewsListNewsArticle newItem = table.CreateInstance<NewsListNewsArticle>();
            NewsListNewsArticle originalItem = repository.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));

            originalItem.CreatedBy = string.Equals(newItem.CreatedBy, "null") ? null : newItem.CreatedBy;
            originalItem.Title = string.Equals(newItem.Title, "null") ? null : newItem.Title;
            originalItem.Content = string.Equals(newItem.Content, "null") ? null : newItem.Content;

            repository.UnitOfWork.BeginTransaction();
            bool repositoryResult = repository.Update(originalItem);
            bool unitOfWorkResult = repository.UnitOfWork.CommitTransaction();

            ScenarioContextManager.Set("repositoryResult", repositoryResult);
            ScenarioContextManager.Set("unitOfWorkResult", unitOfWorkResult);
        }

        [When(@"I update the news list article to the values below not in a transaction")]
        public void UpdateTheValuesNotInATransaction(Table table)
        {
            NewsListNewsArticle newItem = table.CreateInstance<NewsListNewsArticle>();
            NewsListNewsArticle originalItem = repository.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));

            originalItem.CreatedBy = string.Equals(newItem.CreatedBy, "null") ? null : newItem.CreatedBy;
            originalItem.Title = string.Equals(newItem.Title, "null") ? null : newItem.Title;
            originalItem.Content = string.Equals(newItem.Content, "null") ? null : newItem.Content;

            bool repositoryResult = repository.Update(originalItem);

            ScenarioContextManager.Set("repositoryResult", repositoryResult);
        }

        [When(@"I flush the changes")]
        public void FlushTheChanges()
        {
            bool repositoryResult = repository.FlushChanges();
            ScenarioContextManager.Set("repositoryResult", repositoryResult);
        }

        [Then(@"the article repository count should be (.*)")]
        public void TheArticleShouldBePersisted(int count)
        {
            Assert.That(repository.Count(), Is.EqualTo(count));
        }

        [Then(@"the article should not be persisted")]
        public void TheArticleShouldNotBePersisted()
        {
            Assert.That(repository.Count(), Is.EqualTo(0));
        }

        [Then(@"the Creator will be (.*)")]
        public void TheCreatorWillBe(string creator)
        {
            NewsListNewsArticle item = repository.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));
            Assert.That(item.CreatedBy, Is.EqualTo(creator));
        }

        [Then(@"the Title will be (.*)")]
        public void TheTitleWillBe(string title)
        {
            NewsListNewsArticle item = repository.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));
            Assert.That(item.Title, Is.EqualTo(title));
        }

        [Then(@"the Content will be (.*)")]
        public void TheContentWillBe(string content)
        {
            NewsListNewsArticle item = repository.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));
            Assert.That(item.Content, Is.EqualTo(content));
        }

        [Then(@"the repository result will be (.*)")]
        public void TheRepositoryResultWillBe(string expectedResult)
        {
            bool repositoryResult = ScenarioContextManager.Get<bool>("repositoryResult");

            if (string.Equals(expectedResult, "true"))
                Assert.That(repositoryResult, Is.True);
            else if (string.Equals(expectedResult, "false"))
                Assert.That(repositoryResult, Is.False);
        }

        [Then(@"the unit of work result will be (.*)")]
        public void TheUnitOfWorkResultWillBe(string expectedResult)
        {
            bool unitOfWorkResult = ScenarioContextManager.Get<bool>("unitOfWorkResult");

            if (string.Equals(expectedResult, "true"))
                Assert.That(unitOfWorkResult, Is.True);
            else if (string.Equals(expectedResult, "false"))
                Assert.That(unitOfWorkResult, Is.False);
        }

        private NewsListNewsArticle GetNewsManagementNewsArticleTestObject(Guid? id = null)
        {
            NewsListNewsArticle article = ScenarioContextManager.Get<NewsListNewsArticle>("newsArticle");

            if (article == null)
            {
                Guid identifier;

                if (id == null)
                    identifier = ScenarioContextManager.Get<Guid>("newsArticleIdentifier");
                else
                    identifier = (Guid) id;

                article = repository.GetById(identifier);
            }

            return article;
        }
    }
}
