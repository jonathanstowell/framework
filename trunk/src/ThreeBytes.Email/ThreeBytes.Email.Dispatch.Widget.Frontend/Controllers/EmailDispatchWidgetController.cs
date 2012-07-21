using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Configuration.Abstract;
using ThreeBytes.Email.Dispatch.Widget.Entities;
using ThreeBytes.Email.Dispatch.Widget.Service.Abstract;

namespace ThreeBytes.Email.Dispatch.Widget.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class EmailDispatchWidgetController : StatelessSessionController
    {
        private readonly IEmailDispatchWidgetEmailMessageService service;
        private readonly IProvideEmailConfiguration configuration;

        public EmailDispatchWidgetController(IEmailDispatchWidgetEmailMessageService service, IProvideEmailConfiguration configuration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.configuration = configuration;
        }

        [HttpGet]
        public ActionResult MostRecent()
        {
            IList<EmailDispatchWidgetEmailMessage> emails = service.GetMostRecent(10, configuration.ApplicationName);

            if (Request.IsAjaxRequest())
                return Json(new { Items = emails }, JsonRequestBehavior.AllowGet);

            return PartialView(emails);
        }
    }
}
