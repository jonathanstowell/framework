using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Security.Utilities.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.ProjectHollywood.News.Management.Entities;
using ThreeBytes.ProjectHollywood.News.Management.Frontend.PreCommands;
using ThreeBytes.ProjectHollywood.News.Management.Service.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Entities.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;

namespace ThreeBytes.ProjectHollywood.News.Management.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "NewsManager" })]
    public class NewsManagementController : StatelessSessionController
    {
        private readonly INewsManagementNewsArticleService service;
        private readonly IProvideCurrentUserDetails currentUserDetails;
        private readonly ICurrentlyViewingUserService currentlyViewingUserService;

        private readonly Func<CreatedNewsArticlePreCommand> createNewsArticlePreCommandAccessor;
        private readonly Func<DeletedNewsArticlePreCommand> deletedNewsArticlePreCommandAccessor;
        private readonly Func<RenameNewsArticleTitlePreCommand> renameNewsArticleTitlePreCommandAccessor;
        private readonly Func<UpdateNewsArticleContentPreCommand> updateNewsArticleContentPreCommandAccessor;

        public NewsManagementController(INewsManagementNewsArticleService service, IProvideCurrentUserDetails currentUserDetails, Func<CreatedNewsArticlePreCommand> createNewsArticlePreCommandAccessor, Func<DeletedNewsArticlePreCommand> deletedNewsArticlePreCommandAccessor, Func<RenameNewsArticleTitlePreCommand> renameNewsArticleTitlePreCommandAccessor, Func<UpdateNewsArticleContentPreCommand> updateNewsArticleContentPreCommandAccessor, ICurrentlyViewingUserService currentlyViewingUserService)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (currentUserDetails == null)
                throw new ArgumentNullException("currentUserDetails");

            this.service = service;
            this.currentUserDetails = currentUserDetails;
            
            this.createNewsArticlePreCommandAccessor = createNewsArticlePreCommandAccessor;
            this.deletedNewsArticlePreCommandAccessor = deletedNewsArticlePreCommandAccessor;
            this.renameNewsArticleTitlePreCommandAccessor = renameNewsArticleTitlePreCommandAccessor;
            this.updateNewsArticleContentPreCommandAccessor = updateNewsArticleContentPreCommandAccessor;
            this.currentlyViewingUserService = currentlyViewingUserService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        public ActionResult Create(NewsManagementNewsArticle newsArticle)
        {
            var createNewsArticlePreCommand = createNewsArticlePreCommandAccessor();

            createNewsArticlePreCommand.Title = newsArticle.Title;
            createNewsArticlePreCommand.CreatedBy = currentUserDetails.Username;
            createNewsArticlePreCommand.Content = newsArticle.Content;

            createNewsArticlePreCommand.Execute();

            return Json(createNewsArticlePreCommand.Results);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return PartialView("Edit");
        }

        [HttpPost]
        public ActionResult RenameTitle(Guid id, string title)
        {
            var renameNewsArticleTitlePreCommand = renameNewsArticleTitlePreCommandAccessor();

            renameNewsArticleTitlePreCommand.Id = id;
            renameNewsArticleTitlePreCommand.NewTitle = title;
            renameNewsArticleTitlePreCommand.RenamedBy = currentUserDetails.Username;

            renameNewsArticleTitlePreCommand.Execute();

            return Json(renameNewsArticleTitlePreCommand.Results);
        }

        [HttpPost]
        public ActionResult UpdateContent(Guid id, string content)
        {
            var updateNewsArticleContentPreCommand = updateNewsArticleContentPreCommandAccessor();

            updateNewsArticleContentPreCommand.Id = id;
            updateNewsArticleContentPreCommand.NewContent = content;
            updateNewsArticleContentPreCommand.UpdatedBy = currentUserDetails.Username;

            updateNewsArticleContentPreCommand.Execute();

            return Json(updateNewsArticleContentPreCommand.Results);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return PartialView("Delete");
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var deletedNewsArticlePreCommand = deletedNewsArticlePreCommandAccessor();

            deletedNewsArticlePreCommand.Id = id;
            deletedNewsArticlePreCommand.DeletedBy = currentUserDetails.Username;
            deletedNewsArticlePreCommand.Execute();

            return Json(deletedNewsArticlePreCommand.Results);
        }

        [HttpGet]
        public ActionResult GetNewsArticleForUpdateOrDelete(Guid id)
        {
            NewsManagementNewsArticle newsArticle = service.GetById(id);
            IList<ICurrentlyViewingUser> currentlyViewingUsers = currentlyViewingUserService.GetCurrentlyViewingUsers<NewsManagementNewsArticle>(id);
            return Json(new { NewsArticle = newsArticle, CurrentlyViewingUsers = currentlyViewingUsers }, JsonRequestBehavior.AllowGet);
        }
    }
}
