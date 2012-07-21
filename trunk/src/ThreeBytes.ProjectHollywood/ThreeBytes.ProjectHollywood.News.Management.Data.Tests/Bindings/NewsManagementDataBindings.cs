using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Tests.Helpers;
using ThreeBytes.ProjectHollywood.News.Management.Data.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Data.Concrete;
using ThreeBytes.ProjectHollywood.News.Management.Data.Concrete.Infrastructure;
using ThreeBytes.ProjectHollywood.News.Management.Entities;
using ThreeBytes.ProjectHollywood.News.Management.Tests.Shared;

namespace ThreeBytes.ProjectHollywood.News.Management.Data.Tests.Bindings
{
    [Binding]
    public class NewsManagementDataBindings
    {
        private INewsManagementNewsArticleRepository repository;

        [BeforeScenario]
        public void Setup()
        {
            var databaseFactory = new NewsManagementInMemoryDatabaseFactory(new ProvideInMemoryNewsManagementSessionFactoryInitialisation());

            repository =
                    new NewsManagementNewsArticleRepository(
                        databaseFactory,
                        new NewsManagementUnitOfWork(databaseFactory));
        }

        [AfterScenario]
        public void TearDown()
        {
            repository = null;
        }

        [Given(@"I have no saved news management articles")]
        public void NoSavedNewsManagementArticles()
        {
        }

        [Given(@"I have a news management article with the properties")]
        public void NewsManagementArticleWithProperties(Table table)
        {
            NewsManagementNewsArticle item = table.CreateInstance<NewsManagementNewsArticle>();

            if (string.Equals(item.CreatedBy, "null"))
                item.CreatedBy = null;
            if (string.Equals(item.Title, "null"))
                item.Title = null;
            if (string.Equals(item.Content, "null"))
                item.Content = null;

            ScenarioContextManager.Set("newsArticle", item);
        }

        [Given(@"I have several news management articles with the properties")]
        public void SeveralNewsManagementArticleWithProperties(Table table)
        {
            IEnumerable<NewsManagementNewsArticle> items = table.CreateSet<NewsManagementNewsArticle>();

            foreach (var item in items)
            {
                if (string.Equals(item.CreatedBy, "null"))
                    item.CreatedBy = null;
                if (string.Equals(item.Title, "null"))
                    item.Title = null;
                if (string.Equals(item.Content, "null"))
                    item.Content = null;
            }

            ScenarioContextManager.Set("newsArticles", items);
        }

        [Given(@"I have a saved news management article with the properties")]
        public void SavedNewsManagementArticleWithProperties(Table table)
        {
            NewsManagementNewsArticle item = table.CreateInstance<NewsManagementNewsArticle>();

            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();

            repository.UnitOfWork.BeginTransaction();
            repository.Add(item);
            repository.UnitOfWork.CommitTransaction();

            ScenarioContextManager.Set("newsArticleIdentifier", item.Id);
        }

        [Given(@"I have several saved news management articles with the properties")]
        public void SavedNewsManagementArticlesWithProperties(Table table)
        {
            Thread.Sleep(1000);

            ScenarioContextManager.Set("secondInsertDateTime", DateTime.Now);

            IEnumerable<NewsManagementNewsArticle> items = table.CreateSet<NewsManagementNewsArticle>();

            repository.UnitOfWork.BeginTransaction();
            repository.Add(items);
            repository.UnitOfWork.CommitTransaction();
        }

        [Given(@"then I save more news management articles with the properties")]
        public void SaveMoreNewsManagementArticlesWithProperties(Table table)
        {
            Thread.Sleep(1000);

            IEnumerable<NewsManagementNewsArticle> items = table.CreateSet<NewsManagementNewsArticle>();

            repository.UnitOfWork.BeginTransaction();
            repository.Add(items);
            repository.UnitOfWork.CommitTransaction();
        }

        [Given(@"I have a null news management article")]
        public void NullNewsManagementArticle()
        {
            NewsManagementNewsArticle item = null;
            ScenarioContextManager.Set("newsArticle", item);
        }

        [Given(@"I have several null news management articles")]
        public void NullNewsManagementArticles()
        {
            IList<NewsManagementNewsArticle> items = new List<NewsManagementNewsArticle>();

            for (int i = 0; i < 20; i++)
            {
                items.Add(null);
            }
            
            ScenarioContextManager.Set("newsArticles", items.AsEnumerable());
        }

        [When(@"I attempt to (.*) the article in a transaction")]
        public void PerformDataOperationOnArticleInATransaction(string action)
        {
            bool? repositoryResult = null;

            NewsManagementNewsArticle item = GetNewsManagementNewsArticleTestObject();

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

        [When(@"I attempt to (.*) the articles in a transaction")]
        public void PerformDataOperationOnArticlesInATransaction(string action)
        {
            bool? repositoryResult = null;

            IEnumerable<NewsManagementNewsArticle> items = GetNewsManagementNewsArticleCollectionTestObject();

            repository.UnitOfWork.BeginTransaction();

            if (action == "create")
            {
                repositoryResult = repository.Add(items);
            }
            else if (action == "delete")
            {
                repositoryResult = repository.Delete(items);
            }

            repository.UnitOfWork.CommitTransaction();

            ScenarioContextManager.Set("repositoryResult", repositoryResult);
        }

        [When(@"I query whether the news article was created by (.*)")]
        public void IsNewsArticleCreatedBy(string creator)
        {
            bool repositoryResult = repository.IsNewsArticleCreatedBy(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"), creator);
            ScenarioContextManager.Set("repositoryResult", repositoryResult);
        }

        [When(@"I delete the news management article with the id (.*) in a transaction")]
        public void PerformDeleteDataOperationOnArticleInATransaction(string id)
        {
            NewsManagementNewsArticle item = GetNewsManagementNewsArticleTestObject(Guid.Parse(id));

            repository.UnitOfWork.BeginTransaction();
            repository.Delete(item);
            repository.UnitOfWork.CommitTransaction();

            ScenarioContextManager.Set("newsArticleIdentifier", item.Id);
        }

        [When(@"I attempt to (.*) the article not in a transaction")]
        public void PerformDataOperationOnArticleNotInATransaction(string action)
        {
            bool? repositoryResult = null;
            NewsManagementNewsArticle item = GetNewsManagementNewsArticleTestObject();

            if (action == "create")
            {
                repositoryResult = repository.Add(item);
                ScenarioContextManager.Set("newsArticleIdentifier", item.Id);
            }
            else if (action == "delete")
            {
                repositoryResult = repository.Delete(item);
            }

            ScenarioContextManager.Set("repositoryResult", repositoryResult);
        }

        [When(@"I attempt to (.*) the articles not in a transaction")]
        public void PerformDataOperationOnArticlesNotInATransaction(string action)
        {
            bool? repositoryResult = null;
            IEnumerable<NewsManagementNewsArticle> items = GetNewsManagementNewsArticleCollectionTestObject();

            if (action == "create")
                repositoryResult = repository.Add(items);
            else if (action == "delete")
                repositoryResult = repository.Delete(items);

            ScenarioContextManager.Set("repositoryResult", repositoryResult);
        }

        [When(@"I update the news management article to the values below in a transaction")]
        public void UpdateTheValuesInATransaction(Table table)
        {
            NewsManagementNewsArticle newItem = table.CreateInstance<NewsManagementNewsArticle>();
            NewsManagementNewsArticle originalItem = repository.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));

            originalItem.CreatedBy = string.Equals(newItem.CreatedBy, "null") ? null : newItem.CreatedBy;
            originalItem.Title = string.Equals(newItem.Title, "null") ? null : newItem.Title;
            originalItem.Content = string.Equals(newItem.Content, "null") ? null : newItem.Content;

            repository.UnitOfWork.BeginTransaction();
            bool repositoryResult = repository.Update(originalItem);
            bool unitOfWorkResult = repository.UnitOfWork.CommitTransaction();

            ScenarioContextManager.Set("repositoryResult", repositoryResult);
            ScenarioContextManager.Set("unitOfWorkResult", unitOfWorkResult);
        }

        [When(@"I update the news management articles to the values below in a transaction using (.*) as the identifier")]
        public void UpdateNewsManagementArticlesTheValuesInATransaction(string identifier, Table table)
        {
            IEnumerable<NewsManagementNewsArticle> newItems = table.CreateSet<NewsManagementNewsArticle>();
            IEnumerable<NewsManagementNewsArticle> originalItems = repository.GetAll();

            foreach (var item in originalItems)
            {
                NewsManagementNewsArticle newItem = null;

                if (identifier == "Created By")
                    newItem = newItems.SingleOrDefault(x => x.CreatedBy == item.CreatedBy);
                else if (identifier == "Title")
                    newItem = newItems.SingleOrDefault(x => x.Title == item.Title);
                else if (identifier == "Content")
                    newItem = newItems.SingleOrDefault(x => x.Content == item.Content);

                item.CreatedBy = string.Equals(newItem.CreatedBy, "null") ? null : newItem.CreatedBy;
                item.Title = string.Equals(newItem.Title, "null") ? null : newItem.Title;
                item.Content = string.Equals(newItem.Content, "null") ? null : newItem.Content;
            }

            repository.UnitOfWork.BeginTransaction();
            bool repositoryResult = repository.Update(originalItems);
            bool unitOfWorkResult = repository.UnitOfWork.CommitTransaction();

            ScenarioContextManager.Set("repositoryResult", repositoryResult);
            ScenarioContextManager.Set("unitOfWorkResult", unitOfWorkResult);
        }

        [When(@"I update the news management article to the values below not in a transaction")]
        public void UpdateTheValuesNotInATransaction(Table table)
        {
            NewsManagementNewsArticle newItem = table.CreateInstance<NewsManagementNewsArticle>();
            NewsManagementNewsArticle originalItem = repository.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));

            originalItem.CreatedBy = string.Equals(newItem.CreatedBy, "null") ? null : newItem.CreatedBy;
            originalItem.Title = string.Equals(newItem.Title, "null") ? null : newItem.Title;
            originalItem.Content = string.Equals(newItem.Content, "null") ? null : newItem.Content;

            bool repositoryResult = repository.Update(originalItem);

            ScenarioContextManager.Set("repositoryResult", repositoryResult);
        }

        [When(@"I update the news management articles to the values below not in a transaction using (.*) as the identifier")]
        public void UpdateNewsManagementArticlesTheValuesNotInATransaction(string identifier, Table table)
        {
            IEnumerable<NewsManagementNewsArticle> newItems = table.CreateSet<NewsManagementNewsArticle>();
            IEnumerable<NewsManagementNewsArticle> originalItems = repository.GetAll();

            foreach (var item in originalItems)
            {
                NewsManagementNewsArticle newItem = null;

                if (identifier == "Created By")
                    newItem = newItems.SingleOrDefault(x => x.CreatedBy == item.CreatedBy);
                else if (identifier == "Title")
                    newItem = newItems.SingleOrDefault(x => x.Title == item.Title);
                else if (identifier == "Content")
                    newItem = newItems.SingleOrDefault(x => x.Content == item.Content);

                item.CreatedBy = string.Equals(newItem.CreatedBy, "null") ? null : newItem.CreatedBy;
                item.Title = string.Equals(newItem.Title, "null") ? null : newItem.Title;
                item.Content = string.Equals(newItem.Content, "null") ? null : newItem.Content;
            }

            bool repositoryResult = repository.Update(originalItems);

            ScenarioContextManager.Set("repositoryResult", repositoryResult);
        }

        [When(@"I flush the changes")]
        public void FlushTheChanges()
        {
            bool repositoryResult = repository.FlushChanges();
            ScenarioContextManager.Set("repositoryResult", repositoryResult);
        }

        [When(@"I get all articles")]
        public void GetAll()
        {
            ScenarioContextManager.Set("repositoryGetAllResult", repository.GetAll());
        }

        [When(@"I get the (.*) most recent articles")]
        public void GetMostRecent(int take)
        {
            ScenarioContextManager.Set("repositoryGetAllResult", repository.GetMostRecent(take));
        }

        [When(@"I get the most recent articles using the time the second saved batch occurred")]
        public void GetLatestSince()
        {
            DateTime dateTime = ScenarioContextManager.Get<DateTime>("secondInsertDateTime");
            ScenarioContextManager.Set("repositoryGetMostRecentResult", repository.GetLatestSince(dateTime));
        }

        [When(@"I get all articles paged requesting the (.*) page with a page size of (.*)")]
        public void GetAllPaged(string page, int pageSize)
        {
            int pageRequested = 0;

            if (page == "first")
                pageRequested = 1;
            else if (page == "second")
                pageRequested = 2;
            else
                pageRequested = int.Parse(page);

            ScenarioContextManager.Set("repositoryGetAllPagedResult", repository.GetAllPaged(pageSize, null, pageRequested));
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
            NewsManagementNewsArticle item = repository.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));
            Assert.That(item.CreatedBy, Is.EqualTo(creator));
        }

        [Then(@"the Title will be (.*)")]
        public void TheTitleWillBe(string title)
        {
            NewsManagementNewsArticle item = repository.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));
            Assert.That(item.Title, Is.EqualTo(title));
        }

        [Then(@"the Content will be (.*)")]
        public void TheContentWillBe(string content)
        {
            NewsManagementNewsArticle item = repository.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));
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

        [Then(@"there should be an article created by (.*) with the title (.*) and the content (.*)")]
        public void ThereShouldBeAnAricleCreatedByWithTitleWithContent(string createdBy, string title, string content)
        {
            IList<NewsManagementNewsArticle> articles = repository.GetAll();
            Assert.That(articles.Any(x => x.CreatedBy == createdBy && x.Title == title && x.Content == content), Is.True);
        }

        [Then(@"the article list result should contain (.*) items")]
        public void TheGetAllResultShouldContain(int count)
        {
            IList<NewsManagementNewsArticle> articles = ScenarioContextManager.Get<IList<NewsManagementNewsArticle>>("repositoryGetAllResult");
            Assert.That(articles.Count.Equals(count), Is.True);
        }

        [Then(@"there should be an article in the list created by (.*) with the title (.*) and the content (.*)")]
        public void ThereShouldBeAnAricleCreatedByWithTitleWithContentInTheGetAllResultList(string createdBy, string title, string content)
        {
            IList<NewsManagementNewsArticle> articles = ScenarioContextManager.Get<IList<NewsManagementNewsArticle>>("repositoryGetAllResult");
            Assert.That(articles.Any(x => x.CreatedBy == createdBy && x.Title == title && x.Content == content), Is.True);
        }

        [Then(@"there should be an article in the paged list created by (.*) with the title (.*) and the content (.*)")]
        public void ThereShouldBeAnAricleCreatedByWithTitleWithContentInThePagedGetAllResultList(string createdBy, string title, string content)
        {
            IPagedResult<NewsManagementNewsArticle> pagedArticles = ScenarioContextManager.Get<IPagedResult<NewsManagementNewsArticle>>("repositoryGetAllPagedResult");
            Assert.That(pagedArticles.Items.Any(x => x.CreatedBy == createdBy && x.Title == title && x.Content == content), Is.True);
        }

        [Then(@"the paged article result should contain (.*) items")]
        public void PagedResultHasNItems(int count)
        {
            IPagedResult<NewsManagementNewsArticle> pagedArticles = ScenarioContextManager.Get<IPagedResult<NewsManagementNewsArticle>>("repositoryGetAllPagedResult");
            Assert.That(pagedArticles.Items.Count().Equals(count), Is.True);
        }

        [Then(@"the paged article result page count should be (.*)")]
        public void PagedResultHasNPages(int count)
        {
            IPagedResult<NewsManagementNewsArticle> pagedArticles = ScenarioContextManager.Get<IPagedResult<NewsManagementNewsArticle>>("repositoryGetAllPagedResult");
            Assert.That(pagedArticles.PageCount.Equals(count), Is.True);
        }

        [Then(@"the paged article result total item count should be (.*)")]
        public void PagedResultTotalItemCountEquals(int count)
        {
            IPagedResult<NewsManagementNewsArticle> pagedArticles = ScenarioContextManager.Get<IPagedResult<NewsManagementNewsArticle>>("repositoryGetAllPagedResult");
            Assert.That(pagedArticles.TotalItemCount.Equals(count), Is.True);
        }

        [Then(@"the paged article result page number should be (.*)")]
        public void PagedResultPageNumberEquals(int count)
        {
            IPagedResult<NewsManagementNewsArticle> pagedArticles = ScenarioContextManager.Get<IPagedResult<NewsManagementNewsArticle>>("repositoryGetAllPagedResult");
            Assert.That(pagedArticles.PageNumber.Equals(count), Is.True);
        }

        [Then(@"the paged article result page size should be (.*)")]
        public void PagedResultPageSizeEquals(int count)
        {
            IPagedResult<NewsManagementNewsArticle> pagedArticles = ScenarioContextManager.Get<IPagedResult<NewsManagementNewsArticle>>("repositoryGetAllPagedResult");
            Assert.That(pagedArticles.PageSize.Equals(count), Is.True);
        }

        [Then(@"the paged article result has previous page should be (.*)")]
        public void PagedResultPreviousPageEquals(bool flag)
        {
            IPagedResult<NewsManagementNewsArticle> pagedArticles = ScenarioContextManager.Get<IPagedResult<NewsManagementNewsArticle>>("repositoryGetAllPagedResult");
            Assert.That(pagedArticles.HasPreviousPage.Equals(flag), Is.True);
        }

        [Then(@"the paged article result has next page should be (.*)")]
        public void PagedResultNextPageEquals(bool flag)
        {
            IPagedResult<NewsManagementNewsArticle> pagedArticles = ScenarioContextManager.Get<IPagedResult<NewsManagementNewsArticle>>("repositoryGetAllPagedResult");
            Assert.That(pagedArticles.HasNextPage.Equals(flag), Is.True);
        }

        [Then(@"the paged article result is first page should be (.*)")]
        public void PagedResultFirstPageEquals(bool flag)
        {
            IPagedResult<NewsManagementNewsArticle> pagedArticles = ScenarioContextManager.Get<IPagedResult<NewsManagementNewsArticle>>("repositoryGetAllPagedResult");
            Assert.That(pagedArticles.IsFirstPage.Equals(flag), Is.True);
        }

        [Then(@"the paged article result is last page should be (.*)")]
        public void PagedResultLastPageEquals(bool flag)
        {
            IPagedResult<NewsManagementNewsArticle> pagedArticles = ScenarioContextManager.Get<IPagedResult<NewsManagementNewsArticle>>("repositoryGetAllPagedResult");
            Assert.That(pagedArticles.IsLastPage.Equals(flag), Is.True);
        }

        [Then(@"the most recent article list should contain (.*) items")]
        public void TheMostRecentResultShouldContain(int count)
        {
            IMostRecentResult<NewsManagementNewsArticle> articles = ScenarioContextManager.Get<IMostRecentResult<NewsManagementNewsArticle>>("repositoryGetMostRecentResult");
            Assert.That(articles.Items.Count.Equals(count), Is.True);
        }

        [Then(@"there should be an article in the most recent list created by (.*) with the title (.*) and the content (.*)")]
        public void ThereShouldBeAnAricleCreatedByWithTitleWithContentInTheMostRecentResultList(string createdBy, string title, string content)
        {
            IMostRecentResult<NewsManagementNewsArticle> articles = ScenarioContextManager.Get<IMostRecentResult<NewsManagementNewsArticle>>("repositoryGetMostRecentResult");
            Assert.That(articles.Items.Any(x => x.CreatedBy == createdBy && x.Title == title && x.Content == content), Is.True);
        }

        private NewsManagementNewsArticle GetNewsManagementNewsArticleTestObject(Guid? id = null)
        {
            NewsManagementNewsArticle article = ScenarioContextManager.Get<NewsManagementNewsArticle>("newsArticle");

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

        private IEnumerable<NewsManagementNewsArticle> GetNewsManagementNewsArticleCollectionTestObject()
        {
            IEnumerable<NewsManagementNewsArticle> articles = ScenarioContextManager.Get<IEnumerable<NewsManagementNewsArticle>>("newsArticles");

            if (articles == null)
            {

                articles = repository.GetAll();
            }

            return articles;
        }
    }
}
