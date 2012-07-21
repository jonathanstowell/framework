using System;
using System.Web.Mvc;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Configuration.Abstract;
using ThreeBytes.Email.Dispatch.List.Entities;
using ThreeBytes.Email.Dispatch.List.Entities.Enums;
using ThreeBytes.Email.Dispatch.List.Frontend.Models;
using ThreeBytes.Email.Dispatch.List.Service.Abstract;

namespace ThreeBytes.Email.Dispatch.List.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class EmailDispatchListController : StatelessSessionController
    {
        private readonly IEmailDispatchListEmailMessageService service;
        private readonly IProvideEmailConfiguration configuration;

        public EmailDispatchListController(IEmailDispatchListEmailMessageService service, IProvideEmailConfiguration configuration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (configuration == null)
                throw new ArgumentNullException("configuration");

            this.service = service;
            this.configuration = configuration;
        }

        [HttpGet]
        public ActionResult List()
        {
            IPagedResult<EmailDispatchListEmailMessage> dispatchedEmails = service.GetAllPaged(10, null, configuration.ApplicationName);
            return PartialView(new PagedEmailDispatchListEmailMessageViewModel(dispatchedEmails));
        }

        [HttpGet]
        public JsonResult GetPage(int? page, DateTime? datetime, EmailDispatchListOrderBy? orderBy, SortBy? sortBy)
        {
            IPagedResult<EmailDispatchListEmailMessage> dispatchedEmails = service.GetAllPaged(10, datetime, configuration.ApplicationName, orderBy ?? EmailDispatchListOrderBy.CreationDateTime, sortBy ?? SortBy.Desc, page ?? 1);
            return Json(dispatchedEmails, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNewerThan(DateTime datetime)
        {
            IMostRecentResult<EmailDispatchListEmailMessage> mostRecentRoles = service.GetLatestSince(datetime, configuration.ApplicationName);
            return Json(mostRecentRoles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(Guid id)
        {
            EmailDispatchListEmailMessage item = service.GetById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
