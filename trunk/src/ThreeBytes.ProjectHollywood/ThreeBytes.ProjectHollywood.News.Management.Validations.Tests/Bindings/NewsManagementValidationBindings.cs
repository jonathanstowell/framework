using System;
using System.Linq;
using FluentValidation.Results;
using NUnit.Framework;
using Rhino.Mocks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ThreeBytes.Core.Tests.Helpers;
using ThreeBytes.ProjectHollywood.News.Management.Entities;
using ThreeBytes.ProjectHollywood.News.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Validations.Concrete.Resolvers;
using ThreeBytes.ProjectHollywood.News.Management.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.News.Management.Validations.Tests.Bindings
{
    [Binding]
    public class NewsManagementValidationBindings
    {
        private INewsManagementNewsArticleService service;
        
        [BeforeScenario]
        public void Setup()
        {
            service = MockRepository.GenerateMock<INewsManagementNewsArticleService>();
        }

        [AfterScenario]
        public void TearDown()
        {
            service = null;
        }

        [Given(@"I have a news management article with the properties")]
        public void NewsManagementArticleWithProperties(Table table)
        {
             ScenarioContextManager.Set("newsArticle", table.CreateInstance<NewsManagementNewsArticle>());
        }

        [Given(@"I do not have a news management article")]
        public void NoNewsManagementArticle()
        {
            ScenarioContextManager.Set("newsArticle", null);
        }

        [Given(@"I have a saved news management article with the properties")]
        public void SavedNewsManagementArticleWithProperties(Table table)
        {
            NewsManagementNewsArticle item = table.CreateInstance<NewsManagementNewsArticle>();

            item.Id = Guid.NewGuid();

            service.Stub(c => c.GetById(item.Id))
                .IgnoreArguments()
                .Return(item);

            service.Stub(c => c.IsNewsArticleCreatedBy(item.Id, item.CreatedBy))
                .Return(true);

            service.Stub(c => c.IsNewsArticleCreatedBy(item.Id, ""))
                .Return(false);

            ScenarioContextManager.Set("newsArticleIdentifier", item.Id);
        }

        [When(@"I rename the Title to (.*)")]
        public void RenameTheTitle(string newTitle)
        {
            NewsManagementNewsArticle article = GetNewsManagementNewsArticleTestObject();

            if (string.Equals(newTitle, "nothing"))
                article.Title = string.Empty;
            else
                article.Title = newTitle;

            ScenarioContextManager.Set("newsArticle", article);
        }

        [When(@"I change the Creator to (.*)")]
        public void ChangeTheCreator(string newCreator)
        {
            NewsManagementNewsArticle article = GetNewsManagementNewsArticleTestObject();

            if (string.Equals(newCreator, "nothing"))
                article.CreatedBy = string.Empty;
            else
                article.CreatedBy = newCreator;

            ScenarioContextManager.Set("newsArticle", article);
        }

        [When(@"I change the Content to (.*)")]
        public void ChangeTheContent(string newContent)
        {
            NewsManagementNewsArticle article = GetNewsManagementNewsArticleTestObject();

            if (string.Equals(newContent, "nothing"))
                article.Content = string.Empty;
            else
                article.Content = newContent;

            ScenarioContextManager.Set("newsArticle", article);
        }

        [When(@"I validate the (.*)")]
        public void Validate(string type)
        {
            INewsManagementNewsArticleValidatorResolver newsManagementNewsArticleValidatorResolver;

            newsManagementNewsArticleValidatorResolver = new NewsManagementNewsArticleValidatorResolver(
                () => new CreateNewsManagementNewsArticleValidator(),
                () => new RenameNewsManagementNewsArticleValidator(), 
                () => new DeleteNewsManagementNewsArticleValidator(),
                () => new UpdateContentNewsManagementNewsArticleValidator());

            NewsManagementNewsArticle item = GetNewsManagementNewsArticleTestObject();

            if (type == "creation")
                ScenarioContextManager.Set("validationResult", newsManagementNewsArticleValidatorResolver.CreateValidator().Validate(item));
            if (type == "renaming" || type == "reauthoring")
                ScenarioContextManager.Set("validationResult", newsManagementNewsArticleValidatorResolver.RenameValidator().Validate(item));
            if (type == "content update" || type == "reauthoring")
                ScenarioContextManager.Set("validationResult", newsManagementNewsArticleValidatorResolver.UpdateContentValidator().Validate(item));
            if (type == "deletion")
                ScenarioContextManager.Set("validationResult", newsManagementNewsArticleValidatorResolver.DeleteValidator().Validate(item));
        }

        [Then(@"the result should be valid")]
        public void TheResultShouldBeValid()
        {
            Assert.That(ScenarioContextManager.Get<ValidationResult>("validationResult").IsValid, Is.True);
        }

        [Then(@"the result should be invalid")]
        public void TheResultShouldBeInvalid()
        {
            Assert.That(ScenarioContextManager.Get<ValidationResult>("validationResult").IsValid, Is.Not.True);
        }

        [Then(@"there should be (.*) error")]
        public void TheResultShouldHaveError(int count)
        {
            Assert.That(ScenarioContextManager.Get<ValidationResult>("validationResult").Errors.Count, Is.EqualTo(count));
        }

        [Then(@"there should be (.*) errors")]
        public void TheResultShouldHaveErrors(int count)
        {
            Assert.That(ScenarioContextManager.Get<ValidationResult>("validationResult").Errors.Count, Is.EqualTo(count));
        }

        [Then(@"there should be an error for (.*) with message (.*)")]
        public void TheResultShouldHaveAnErrorWithMessage(string property, string errorMessage)
        {
            Assert.That(ScenarioContextManager.Get<ValidationResult>("validationResult").Errors.Any(x => x.PropertyName == property && x.ErrorMessage == errorMessage), Is.True);
        }

        [Then(@"get by id should have been called on the news management service")]
        public void GetByIdShouldBeCalledOnTheNewsManagementService()
        {
            service.AssertWasCalled(c => c.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier")));
        }

        private NewsManagementNewsArticle GetNewsManagementNewsArticleTestObject()
        {
            NewsManagementNewsArticle article = ScenarioContextManager.Get<NewsManagementNewsArticle>("newsArticle");

            if (article == null)
            {
                Guid id = ScenarioContextManager.Get<Guid>("newsArticleIdentifier");

                if (id != null)
                {
                    article = service.GetById(id);
                }
            }

            return article;
        }
    }
}
