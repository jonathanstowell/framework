using System;
using System.Web.Mvc;
using FluentValidation.Results;
using MvcContrib.TestHelper;
using NServiceBus;
using NUnit.Framework;
using Rhino.Mocks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ThreeBytes.Core.Security.Utilities.Abstract;
using ThreeBytes.Core.Tests.Helpers;
using ThreeBytes.ProjectHollywood.News.Management.Entities;
using ThreeBytes.ProjectHollywood.News.Management.Frontend.Controllers;
using ThreeBytes.ProjectHollywood.News.Management.Frontend.PreCommands;
using ThreeBytes.ProjectHollywood.News.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.News.Management.Validations.Concrete.Resolvers;
using ThreeBytes.ProjectHollywood.News.Management.Validations.Concrete.Validators;

namespace ThreeBytes.ProjectHollywood.News.Management.Frontend.Tests.Bindings
{
    [Binding]
    public class NewsManagementFrontendBindings
    {
        [BeforeScenario]
        public void Setup()
        {
        }

        [AfterScenario]
        public void TearDown()
        {
        }

        [Given(@"I have a mocked service")]
        public void IHaveAMockedService()
        {
            INewsManagementNewsArticleService service = MockRepository.GenerateStub<INewsManagementNewsArticleService>();
            ScenarioContextManager.Set("service", service);
        }

        [Given(@"I have a mocked current user details")]
        public void IHaveAMockedCurrentUserDetails()
        {
            IProvideCurrentUserDetails currentUserDetails = MockRepository.GenerateStub<IProvideCurrentUserDetails>();
            ScenarioContextManager.Set("currentUserDetails", currentUserDetails);
        }

        [Given(@"I have a null current user details")]
        public void IHaveANullCurrentUserDetails()
        {
            IProvideCurrentUserDetails currentUserDetails = null;
            ScenarioContextManager.Set("currentUserDetails", currentUserDetails);
        }

        [Given(@"I have a null service")]
        public void IHaveANullService()
        {
            INewsManagementNewsArticleService service = null;
            ScenarioContextManager.Set("service", service);
        }

        [Given(@"I have a mocked service bus")]
        public void IHaveAMockedServiceBus()
        {
            IBus bus = MockRepository.GenerateMock<IBus>();
            ScenarioContextManager.Set("bus", bus);
        }

        [Given(@"I have a null service bus")]
        public void IHaveANullServiceBus()
        {
            IBus bus = null;
            ScenarioContextManager.Set("bus", bus);
        }

        [Given(@"I have a validation resolver")]
        public void IHaveAValidationResolver()
        {
            INewsManagementNewsArticleService service = ScenarioContextManager.Get<INewsManagementNewsArticleService>("service");

            INewsManagementNewsArticleValidatorResolver newsManagementNewsArticleValidatorResolver = new NewsManagementNewsArticleValidatorResolver(
                () => new CreateNewsManagementNewsArticleValidator(),
                () => new UpdateNewsListNewsArticleValidator(service),
                () => new DeleteNewsListNewsArticleValidator());

            ScenarioContextManager.Set("validationResolver", newsManagementNewsArticleValidatorResolver);
        }

        [Given(@"I have a null validation resolver")]
        public void IHaveANullValidationResolver()
        {
            INewsManagementNewsArticleValidatorResolver resolver = null;
            ScenarioContextManager.Set("nullValidationResolver", resolver);
        }

        [Given(@"I have a news management article with the properties")]
        public void NewsManagementArticleWithProperties(Table table)
        {
            ScenarioContextManager.Set("newsArticle", table.CreateInstance<NewsManagementNewsArticle>());
        }

        [Given(@"I have a saved news management article with the properties")]
        public void SavedNewsManagementArticleWithProperties(Table table)
        {
            INewsManagementNewsArticleService service = ScenarioContextManager.Get<INewsManagementNewsArticleService>("service");

            NewsManagementNewsArticle item = table.CreateInstance<NewsManagementNewsArticle>();

            if (item.Id == Guid.Empty)
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

        [Given(@"the current user is (.*)")]
        public void CurrentUserIs(string username)
        {
            IProvideCurrentUserDetails currentUserDetails = ScenarioContextManager.Get<IProvideCurrentUserDetails>("currentUserDetails");

            currentUserDetails.Stub(c => c.Username)
                .Return(username);
        }

        [Given(@"I do not have a saved news management article with the identifier (.*)")]
        public void DoNotHaveASavedNewsManagementArticle(string id)
        {
            INewsManagementNewsArticleService service = ScenarioContextManager.Get<INewsManagementNewsArticleService>("service");

            NewsManagementNewsArticle item = null;

            service.Stub(c => c.GetById(Guid.Parse(id)))
                .IgnoreArguments()
                .Return(item);

            ScenarioContextManager.Set("newsArticle", item);
        }

        [Given(@"I have a null news management article")]
        public void IHaveANullNewsManagementArticle()
        {
            NewsManagementNewsArticle item = null;
            ScenarioContextManager.Set("newsArticle", item);
        }

        [Given(@"I have a News Management Controller")]
        public void IHaveANewsManagementController()
        {
            INewsManagementNewsArticleService service = ScenarioContextManager.Get<INewsManagementNewsArticleService>("service");
            INewsManagementNewsArticleValidatorResolver validationResolver = ScenarioContextManager.Get<INewsManagementNewsArticleValidatorResolver>("validationResolver");
            IBus bus = ScenarioContextManager.Get<IBus>("bus");
            IProvideCurrentUserDetails currentUserDetails = ScenarioContextManager.Get<IProvideCurrentUserDetails>("currentUserDetails");

            NewsManagementController controller = new NewsManagementController(service, currentUserDetails, () => new CreatedNewsArticlePreCommand(bus, validationResolver), () => new DeletedNewsArticlePreCommand(bus, validationResolver, service), () => new RenameNewsArticleTitlePreCommand(bus, validationResolver, service), () => new UpdateNewsArticleContentPreCommand(bus, validationResolver, service));
            ScenarioContextManager.Set("controller", controller);
        }

        [Given(@"I setup the (.*) pre command")]
        public void SetupPreCommand(string commandType)
        {
            INewsManagementNewsArticleService service = ScenarioContextManager.Get<INewsManagementNewsArticleService>("service");
            INewsManagementNewsArticleValidatorResolver validationResolver = ScenarioContextManager.Get<INewsManagementNewsArticleValidatorResolver>("validationResolver");
            IBus bus = ScenarioContextManager.Get<IBus>("bus");

            NewsManagementNewsArticle item = GetNewsManagementNewsArticleTestObject();

            if (commandType == "create")
            {
                CreatedNewsArticlePreCommand cmd = new CreatedNewsArticlePreCommand(bus, validationResolver);

                cmd.Bus = bus;
                cmd.Content = item.Content;
                cmd.CreatedBy = item.CreatedBy;
                cmd.Title = item.Title;

                ScenarioContextManager.Set("command", cmd);
            }
            else if (commandType == "rename")
            {
                RenameNewsArticleTitlePreCommand cmd = new RenameNewsArticleTitlePreCommand(bus, validationResolver, service);

                cmd.Bus = bus;
                cmd.Id = item.Id;
                cmd.NewTitle = item.Title;

                ScenarioContextManager.Set("command", cmd);
            }
            else if (commandType == "update content")
            {
                UpdateNewsArticleContentPreCommand cmd = new UpdateNewsArticleContentPreCommand(bus, validationResolver, service);

                cmd.Bus = bus;
                cmd.Id = item.Id;
                cmd.NewContent = item.Content;

                ScenarioContextManager.Set("command", cmd);
            }
            else if (commandType == "deletion")
            {
                DeletedNewsArticlePreCommand cmd = new DeletedNewsArticlePreCommand(bus, validationResolver, service);

                cmd.Bus = bus;
                cmd.Id = item.Id;

                ScenarioContextManager.Set("command", cmd);
            }
        }

        [Given(@"I initialise the DeletedNewsArticlePreCommand to delete the news management article with the identifier (.*)")]
        public void SetupDeletePreCommandToDelete(string id)
        {
            INewsManagementNewsArticleService service = ScenarioContextManager.Get<INewsManagementNewsArticleService>("service");
            INewsManagementNewsArticleValidatorResolver validationResolver = ScenarioContextManager.Get<INewsManagementNewsArticleValidatorResolver>("validationResolver");
            IBus bus = ScenarioContextManager.Get<IBus>("bus");

            DeletedNewsArticlePreCommand cmd = new DeletedNewsArticlePreCommand(bus, validationResolver, service);

            cmd.Bus = bus;
            cmd.Id = Guid.Parse(id);

            cmd.Execute();

            ScenarioContextManager.Set("command", cmd);
        }

        [When(@"I rename the Title to (.*)")]
        [Given(@"I rename the Title to (.*)")]
        public void RenameTheTitle(string newTitle)
        {
            NewsManagementNewsArticle article = GetNewsManagementNewsArticleTestObject();

            if (string.Equals(newTitle, "nothing"))
                article.Title = string.Empty;
            else
                article.Title = newTitle;

            ScenarioContextManager.Set("newsArticle", article);
        }

        [When(@"I change the Content to (.*)")]
        [Given(@"I change the Content to (.*)")]
        public void ChangeTheContent(string newContent)
        {
            NewsManagementNewsArticle article = GetNewsManagementNewsArticleTestObject();

            if (string.Equals(newContent, "nothing"))
                article.Content = string.Empty;
            else
                article.Content = newContent;

            ScenarioContextManager.Set("newsArticle", article);
        }

        [When(@"I execute the (.*) pre command")]
        public void ExecuteTheCommand(string commandType)
        {
            if (commandType == "create")
            {
                CreatedNewsArticlePreCommand cmd = ScenarioContextManager.Get<CreatedNewsArticlePreCommand>("command");

                cmd.Execute();

                ScenarioContextManager.Set("command", cmd);
            }
            else if (commandType == "rename")
            {
                RenameNewsArticleTitlePreCommand cmd = ScenarioContextManager.Get<RenameNewsArticleTitlePreCommand>("command");

                cmd.Execute();

                ScenarioContextManager.Set("command", cmd);
            }
            else if (commandType == "update content")
            {
                UpdateNewsArticleContentPreCommand cmd = ScenarioContextManager.Get<UpdateNewsArticleContentPreCommand>("command");

                cmd.Execute();

                ScenarioContextManager.Set("command", cmd);
            }
            else if (commandType == "deletion")
            {
                DeletedNewsArticlePreCommand cmd = ScenarioContextManager.Get<DeletedNewsArticlePreCommand>("command");

                cmd.Execute();

                ScenarioContextManager.Set("command", cmd);
            }
        }

        [When(@"I execute the (.*) GET action")]
        public void IExecuteTheCreateGetAction(string method)
        {
            NewsManagementController controller = ScenarioContextManager.Get<NewsManagementController>("controller");
            ActionResult actionResult = null;

            if (method == "Create")
            {
                actionResult = controller.Create();
            }
            else if (method == "Edit")
            {
                actionResult = controller.Edit();
            }
            else if (method == "Delete")
            {
                actionResult = controller.Delete();
            }

            ScenarioContextManager.Set("actionResult", actionResult);
        }

        [When(@"I execute the Rename POST action with id as (.*) and title as (.*)")]
        public void IExecuteTheRenamePostAction(string id, string newTitle)
        {
            if (string.Equals(newTitle, "nothing"))
                newTitle = string.Empty;

            NewsManagementController controller = ScenarioContextManager.Get<NewsManagementController>("controller");
            ActionResult actionResult = controller.RenameTitle(Guid.Parse(id), newTitle);
            ScenarioContextManager.Set("actionResult", actionResult);
        }

        [When(@"I execute the UpdateContent POST action with id as (.*) and content as (.*)")]
        public void IExecuteTheUpdateContentPostAction(string id, string newContent)
        {
            if (string.Equals(newContent, "nothing"))
                newContent = string.Empty;

            NewsManagementController controller = ScenarioContextManager.Get<NewsManagementController>("controller");
            ActionResult actionResult = controller.UpdateContent(Guid.Parse(id), newContent);
            ScenarioContextManager.Set("actionResult", actionResult);
        }

        [When(@"I execute the Delete POST action with id as (.*)")]
        public void IExecuteTheDeletePostAction(string id)
        {
            NewsManagementController controller = ScenarioContextManager.Get<NewsManagementController>("controller");
            ActionResult actionResult = controller.Delete(Guid.Parse(id));
            ScenarioContextManager.Set("actionResult", actionResult);
        }

        [When(@"I execute the Create POST action")]
        public void IExecuteTheCreatePostAction()
        {
            NewsManagementController controller = ScenarioContextManager.Get<NewsManagementController>("controller");
            NewsManagementNewsArticle article = GetNewsManagementNewsArticleTestObject();
            ActionResult actionResult = controller.Create(article);
            ScenarioContextManager.Set("actionResult", actionResult);
        }

        [When(@"I execute the GetNewsArticleForUpdateOrDelete GET action with id as (.*)")]
        public void IExecuteTheGetNewsArticleForUpdateOrDelete(string id)
        {
            NewsManagementController controller = ScenarioContextManager.Get<NewsManagementController>("controller");
            ActionResult actionResult = controller.GetNewsArticleForUpdateOrDelete(Guid.Parse(id));
            ScenarioContextManager.Set("actionResult", actionResult);
        }

        [When(@"I create a (.*)")]
        public void ICreateA(string type)
        {
            INewsManagementNewsArticleService service = ScenarioContextManager.Get<INewsManagementNewsArticleService>("service");
            INewsManagementNewsArticleValidatorResolver validationResolver = ScenarioContextManager.Get<INewsManagementNewsArticleValidatorResolver>("validationResolver");
            IBus bus = ScenarioContextManager.Get<IBus>("bus");
            IProvideCurrentUserDetails currentUserDetails = ScenarioContextManager.Get<IProvideCurrentUserDetails>("currentUserDetails");

            if (type == "CreatedNewsArticlePreCommand")
            {
                try
                {
                    new CreatedNewsArticlePreCommand(bus, validationResolver);
                }
                catch (Exception ex)
                {
                    ScenarioContextManager.Set("exception", ex);
                }
            }
            else if (type == "DeletedNewsArticlePreCommand")
            {
                try
                {
                    new DeletedNewsArticlePreCommand(bus, validationResolver, service);
                }
                catch (Exception ex)
                {
                    ScenarioContextManager.Set("exception", ex);
                }
            }
            else if (type == "RenameNewsArticleTitlePreCommand")
            {
                try
                {
                    new RenameNewsArticleTitlePreCommand(bus, validationResolver, service);
                }
                catch (Exception ex)
                {
                    ScenarioContextManager.Set("exception", ex);
                }
            }
            else if (type == "UpdateNewsArticleContentPreCommand")
            {
                try
                {
                    new UpdateNewsArticleContentPreCommand(bus, validationResolver, service);
                }
                catch (Exception ex)
                {
                    ScenarioContextManager.Set("exception", ex);
                }
            }
            else if (type == "NewsManagementController")
            {
                try
                {
                    new NewsManagementController(service, currentUserDetails, null, null, null, null);
                }
                catch (Exception ex)
                {
                    ScenarioContextManager.Set("exception", ex);
                }
            }
        }

        [Then(@"the create command result should have executed")]
        public void TheCreateCommandResultShouldHaveExecuted()
        {
            CreatedNewsArticlePreCommand cmd = ScenarioContextManager.Get<CreatedNewsArticlePreCommand>("command");
            Assert.That(cmd.HasExecuted, Is.True);
        }

        [Then(@"the create command result should be valid")]
        public void TheCommandResultShouldBeValid()
        {
            CreatedNewsArticlePreCommand cmd = ScenarioContextManager.Get<CreatedNewsArticlePreCommand>("command");
            Assert.That(cmd.Results.IsValid, Is.True);
        }

        [Then(@"the create command result should be invalid")]
        public void TheCommandResultShouldBeInvalid()
        {
            CreatedNewsArticlePreCommand cmd = ScenarioContextManager.Get<CreatedNewsArticlePreCommand>("command");
            Assert.That(cmd.Results.IsValid, Is.False);
        }

        [Then(@"the rename command result should have executed")]
        public void TheRenameCommandResultShouldHaveExecuted()
        {
            RenameNewsArticleTitlePreCommand cmd = ScenarioContextManager.Get<RenameNewsArticleTitlePreCommand>("command");
            Assert.That(cmd.HasExecuted, Is.True);
        }

        [Then(@"the rename command result should be valid")]
        public void TheRenameResultShouldBeValid()
        {
            RenameNewsArticleTitlePreCommand cmd = ScenarioContextManager.Get<RenameNewsArticleTitlePreCommand>("command");
            Assert.That(cmd.Results.IsValid, Is.True);
        }

        [Then(@"the rename command result should be invalid")]
        public void TheRenameResultShouldBeInvalid()
        {
            RenameNewsArticleTitlePreCommand cmd = ScenarioContextManager.Get<RenameNewsArticleTitlePreCommand>("command");
            Assert.That(cmd.Results.IsValid, Is.False);
        }

        [Then(@"the update content command result should have executed")]
        public void TheUpdateContentCommandResultShouldHaveExecuted()
        {
            UpdateNewsArticleContentPreCommand cmd = ScenarioContextManager.Get<UpdateNewsArticleContentPreCommand>("command");
            Assert.That(cmd.HasExecuted, Is.True);
        }

        [Then(@"the update content command result should be valid")]
        public void TheUpdateContentResultShouldBeValid()
        {
            UpdateNewsArticleContentPreCommand cmd = ScenarioContextManager.Get<UpdateNewsArticleContentPreCommand>("command");
            Assert.That(cmd.Results.IsValid, Is.True);
        }

        [Then(@"the update content command result should be invalid")]
        public void TheUpdateContentResultShouldBeInvalid()
        {
            UpdateNewsArticleContentPreCommand cmd = ScenarioContextManager.Get<UpdateNewsArticleContentPreCommand>("command");
            Assert.That(cmd.Results.IsValid, Is.False);
        }

        [Then(@"the deletion command result should have executed")]
        public void TheDeletionCommandResultShouldHaveExecuted()
        {
            DeletedNewsArticlePreCommand cmd = ScenarioContextManager.Get<DeletedNewsArticlePreCommand>("command");
            Assert.That(cmd.HasExecuted, Is.True);
        }

        [Then(@"the deletion command result should be valid")]
        public void TheDeletionResultShouldBeValid()
        {
            DeletedNewsArticlePreCommand cmd = ScenarioContextManager.Get<DeletedNewsArticlePreCommand>("command");
            Assert.That(cmd.Results.IsValid, Is.True);
        }

        [Then(@"the deletion command result should be invalid")]
        public void TheDeletionResultShouldBeInvalid()
        {
            DeletedNewsArticlePreCommand cmd = ScenarioContextManager.Get<DeletedNewsArticlePreCommand>("command");
            Assert.That(cmd.Results.IsValid, Is.False);
        }

        [Then(@"get by id should have been called on the news management service")]
        public void GetByIdShouldBeCalledOnTheNewsManagementService()
        {
            INewsManagementNewsArticleService service = ScenarioContextManager.Get<INewsManagementNewsArticleService>("service");

            service.AssertWasCalled(c => c.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier")));
        }

        [Then(@"the (.*) partial view should be rendered")]
        public void TheCreatePartialViewShouldBeRendered(string action)
        {
            ActionResult actionResult = ScenarioContextManager.Get<ActionResult>("actionResult");

            if (action == "Create")
            {
                actionResult.AssertPartialViewRendered().ForView("Create");
            }
            else if (action == "Edit")
            {
                actionResult.AssertPartialViewRendered().ForView("Edit");
            }
            else if (action == "Delete")
            {
                actionResult.AssertPartialViewRendered().ForView("Delete");
            }
        }

        [Then(@"a json result will be returned")]
        public void TheJsonValidationResultShouldBeReturned()
        {
            ActionResult actionResult = ScenarioContextManager.Get<ActionResult>("actionResult");
            actionResult.AssertResultIs<JsonResult>();
        }

        [Then(@"the json result it will be null")]
        public void JsonResultIsNull()
        {
            JsonResult actionResult = ScenarioContextManager.Get<JsonResult>("actionResult");
            Assert.IsTrue(actionResult.Data == null);
        }

        [Then(@"it will contain a validation result")]
        public void JsonValidationResult()
        {
            JsonResult actionResult = ScenarioContextManager.Get<JsonResult>("actionResult");
            Assert.IsTrue(actionResult.Data.GetType() == typeof(ValidationResult));
        }

        [Then(@"it will contain a news management article")]
        public void JsonNewsManagementArticle()
        {
            JsonResult actionResult = ScenarioContextManager.Get<JsonResult>("actionResult");
            Assert.IsTrue(actionResult.Data.GetType() == typeof(NewsManagementNewsArticle));
        }

        [Then(@"the result will be (invalid|valid)")]
        public void JsonValidationResultWillBeValid(string type)
        {
            JsonResult actionResult = ScenarioContextManager.Get<JsonResult>("actionResult");

            if (string.Equals(type, "valid"))
                Assert.IsTrue(((ValidationResult) actionResult.Data).IsValid);
            else if (string.Equals(type, "invalid"))
                Assert.IsFalse(((ValidationResult)actionResult.Data).IsValid);
        }

        [Then(@"a null argument exception will be thrown")]
        public void ANullArguementExceptionWillBeThrown()
        {
            Exception ex = ScenarioContextManager.Get<Exception>("exception");
            Assert.IsTrue(ex.GetType() == typeof(ArgumentNullException));
        }

        [Then(@"the json news management article Id will be (.*)")]
        public void TheJsonNewsManagementArticleIdWillBe(string id)
        {
            JsonResult actionResult = ScenarioContextManager.Get<JsonResult>("actionResult");
            Assert.That(((NewsManagementNewsArticle)actionResult.Data).Id, Is.EqualTo(Guid.Parse(id)));
        }

        [Then(@"the json news management article CreatedBy will be (.*)")]
        public void TheJsonNewsManagementArticleCreatedByWillBe(string createdBy)
        {
            JsonResult actionResult = ScenarioContextManager.Get<JsonResult>("actionResult");
            Assert.That(((NewsManagementNewsArticle)actionResult.Data).CreatedBy, Is.EqualTo(createdBy));
        }

        [Then(@"the json news management article Title will be (.*)")]
        public void TheJsonNewsManagementArticleTitleWillBe(string title)
        {
            JsonResult actionResult = ScenarioContextManager.Get<JsonResult>("actionResult");
            Assert.That(((NewsManagementNewsArticle)actionResult.Data).Title, Is.EqualTo(title));
        }

        [Then(@"the json news management article Content will be (.*)")]
        public void TheJsonNewsManagementArticleContentWillBe(string content)
        {
            JsonResult actionResult = ScenarioContextManager.Get<JsonResult>("actionResult");
            Assert.That(((NewsManagementNewsArticle)actionResult.Data).Content, Is.EqualTo(content));
        }

        private NewsManagementNewsArticle GetNewsManagementNewsArticleTestObject()
        {
            INewsManagementNewsArticleService service = ScenarioContextManager.Get<INewsManagementNewsArticleService>("service");

            NewsManagementNewsArticle article = ScenarioContextManager.Get<NewsManagementNewsArticle>("newsArticle");

            if (article == null)
                article = service.GetById(ScenarioContextManager.Get<Guid>("newsArticleIdentifier"));

            return article;
        }
    }
}
