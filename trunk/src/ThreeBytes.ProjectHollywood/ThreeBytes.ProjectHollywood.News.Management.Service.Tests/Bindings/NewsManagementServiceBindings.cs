using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ThreeBytes.Core.Tests.Helpers;
using ThreeBytes.ProjectHollywood.News.Management.Data.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Data.Concrete;
using ThreeBytes.ProjectHollywood.News.Management.Data.Concrete.Infrastructure;
using ThreeBytes.ProjectHollywood.News.Management.Entities;
using ThreeBytes.ProjectHollywood.News.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Service.Concrete;
using ThreeBytes.ProjectHollywood.News.Management.Tests.Shared;

namespace ThreeBytes.ProjectHollywood.News.Management.Service.Tests.Bindings
{
    [Binding]
    public class NewsManagementServiceBindings
    {
        private INewsManagementNewsArticleService service;

        [BeforeScenario]
        public void Setup()
        {
            var databaseFactory = new NewsManagementInMemoryDatabaseFactory(new ProvideInMemoryNewsManagementSessionFactoryInitialisation());

            INewsManagementNewsArticleRepository repository =
                    new NewsManagementNewsArticleRepository(
                        databaseFactory,
                        new NewsManagementUnitOfWork(databaseFactory));

            service = new NewsManagementNewsArticleService(repository);
        }

        [AfterScenario]
        public void TearDown()
        {
            service = null;
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

            service.Create(item);

            ScenarioContextManager.Set("newsArticleIdentifier", item.Id);
        }

        [Given(@"I have several saved news management articles with the properties")]
        public void SavedNewsManagementArticlesWithProperties(Table table)
        {
            IEnumerable<NewsManagementNewsArticle> items = table.CreateSet<NewsManagementNewsArticle>();
            service.Create(items);
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

        [When(@"I attempt to (.*) the article")]
        public void PerformDataOperationOnArticleInATransaction(string action)
        {
            bool? serviceResult = null;
            NewsManagementNewsArticle item = GetNewsManagementNewsArticleTestObject();

            if (action == "create")
            {
                serviceResult = service.Create(item);
                ScenarioContextManager.Set("newsArticleIdentifier", item.Id);
            }
            else if (action == "delete")
            {
                serviceResult = service.Delete(item);
            }

            ScenarioContextManager.Set("serviceResult", serviceResult);
        }

        [When(@"I attempt to (.*) the articles")]
        public void PerformDataOperationOnArticlesInATransaction(string action)
        {
            bool? serviceResult = null;

            IEnumerable<NewsManagementNewsArticle> items = GetNewsManagementNewsArticleCollectionTestObject();

            if (action == "create")
            {
                serviceResult = service.Create(items);
            }
            else if (action == "delete")
            {
                serviceResult = service.Delete(items);
            }

            ScenarioContextManager.Set("serviceResult", serviceResult);
        }

        [When(@"I update the news management article to the values below")]
        public void UpdateTheValuesInATransaction(Table table)
        {
            NewsManagementNewsArticle newItem = table.CreateInstance<NewsManagementNewsArticle>();
            NewsManagementNewsArticle originalItem = GetNewsManagementNewsArticleTestObject();

            originalItem.CreatedBy = string.Equals(newItem.CreatedBy, "null") ? null : newItem.CreatedBy;
            originalItem.Title = string.Equals(newItem.Title, "null") ? null : newItem.Title;
            originalItem.Content = string.Equals(newItem.Content, "null") ? null : newItem.Content;

            bool serviceResult = service.Update(originalItem);

            ScenarioContextManager.Set("serviceResult", serviceResult);
        }

        [When(@"I update the news management articles to the values below using (.*) as the identifier")]
        public void UpdateNewsManagementArticlesTheValuesInATransaction(string identifier, Table table)
        {
            IEnumerable<NewsManagementNewsArticle> newItems = table.CreateSet<NewsManagementNewsArticle>();
            IEnumerable<NewsManagementNewsArticle> originalItems = service.GetAll();

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

            bool serviceResult = service.Update(originalItems);

            ScenarioContextManager.Set("serviceResult", serviceResult);
        }

        [When(@"I query whether the news article was created by (.*)")]
        public void IsNewsArticleCreatedBy(string creator)
        {
            bool repositoryResult = service.IsNewsArticleCreatedBy(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"), creator);
            ScenarioContextManager.Set("serviceResult", repositoryResult);
        }

        [Then(@"the article service count should be (.*)")]
        public void TheArticleShouldNotBePersisted(int count)
        {
            Assert.That(service.Count(), Is.EqualTo(count));
        }

        [Then(@"the Creator will be (.*)")]
        public void TheCreatorWillBe(string creator)
        {
            NewsManagementNewsArticle item = service.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));
            Assert.That(item.CreatedBy, Is.EqualTo(creator));
        }

        [Then(@"the Title will be (.*)")]
        public void TheTitleWillBe(string title)
        {
            NewsManagementNewsArticle item = service.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));
            Assert.That(item.Title, Is.EqualTo(title));
        }

        [Then(@"the Content will be (.*)")]
        public void TheContentWillBe(string content)
        {
            NewsManagementNewsArticle item = service.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));
            Assert.That(item.Content, Is.EqualTo(content));
        }

        [Then(@"the service result will be (.*)")]
        public void TheServiceResultWillBe(bool result)
        {
            bool? serviceResult = ScenarioContextManager.Get<bool?>("serviceResult");
            Assert.That(serviceResult, Is.EqualTo(result));
        }

        [Then(@"there should be an article created by (.*) with the title (.*) and the content (.*)")]
        public void ThereShouldBeAnAricleCreatedByWithTitleWithContent(string createdBy, string title, string content)
        {
            IList<NewsManagementNewsArticle> articles = service.GetAll();
            Assert.That(articles.Any(x => x.CreatedBy == createdBy && x.Title == title && x.Content == content), Is.True);
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
                    identifier = (Guid)id;

                article = service.GetById(identifier);
            }

            return article;
        }

        private IEnumerable<NewsManagementNewsArticle> GetNewsManagementNewsArticleCollectionTestObject()
        {
            IEnumerable<NewsManagementNewsArticle> articles = ScenarioContextManager.Get<IEnumerable<NewsManagementNewsArticle>>("newsArticles");

            if (articles == null)
            {

                articles = service.GetAll();
            }

            return articles;
        }
    }
}
