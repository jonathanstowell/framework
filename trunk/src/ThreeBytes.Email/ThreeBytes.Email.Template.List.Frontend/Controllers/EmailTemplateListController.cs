using System;
using System.Web.Mvc;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Configuration.Abstract;
using ThreeBytes.Email.Template.List.Entities;
using ThreeBytes.Email.Template.List.Entities.Enums;
using ThreeBytes.Email.Template.List.Frontend.Models;
using ThreeBytes.Email.Template.List.Service.Abstract;

namespace ThreeBytes.Email.Template.List.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class EmailTemplateListController : StatelessSessionController
    {
        private readonly IEmailTemplateListTemplateService service;
        private readonly IProvideEmailConfiguration configuration;

        public EmailTemplateListController(IEmailTemplateListTemplateService service, IProvideEmailConfiguration configuration)
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
            IPagedResult<EmailTemplateListTemplate> templates = service.GetAllPaged(10, null, configuration.ApplicationName);
            return PartialView(new PagedEmailTemplateEmailViewModel(templates));
        }

        [HttpGet]
        public JsonResult GetPage(int? page, DateTime? datetime, TemplateListOrderBy? orderBy, SortBy? sortBy)
        {
            IPagedResult<EmailTemplateListTemplate> templates = service.GetAllPaged(10, datetime, configuration.ApplicationName, orderBy ?? TemplateListOrderBy.Name, sortBy ?? SortBy.Asc, page ?? 1);
            return Json(templates, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNewerThan(DateTime datetime)
        {
            IMostRecentResult<EmailTemplateListTemplate> mostRecentTemplates = service.GetLatestSince(datetime, configuration.ApplicationName);
            return Json(mostRecentTemplates, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(Guid id)
        {
            EmailTemplateListTemplate item = service.GetById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
