using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Configuration.Abstract;
using ThreeBytes.Email.Template.Widget.Entities;
using ThreeBytes.Email.Template.Widget.Service.Abstract;

namespace ThreeBytes.Email.Template.Widget.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class EmailTemplateWidgetController : StatelessSessionController
    {
        private readonly IEmailTemplateWidgetTemplateService service;
        private readonly IProvideEmailConfiguration configuration;

        public EmailTemplateWidgetController(IEmailTemplateWidgetTemplateService service, IProvideEmailConfiguration configuration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.configuration = configuration;
        }

        [HttpGet]
        public ActionResult MostRecent()
        {
            IList<EmailTemplateWidgetTemplate> emails = service.GetMostRecent(10, configuration.ApplicationName);

            if (Request.IsAjaxRequest())
                return Json(new { Items = emails }, JsonRequestBehavior.AllowGet);

            return PartialView(emails);
        }
    }
}
