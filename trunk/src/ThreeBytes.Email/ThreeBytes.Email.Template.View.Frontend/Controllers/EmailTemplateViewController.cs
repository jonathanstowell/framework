using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Template.View.Entities;
using ThreeBytes.Email.Template.View.Service.Abstract;

namespace ThreeBytes.Email.Template.View.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class EmailTemplateViewController : StatelessSessionController
    {
        private readonly IEmailTemplateViewTemplateService service;

        public EmailTemplateViewController(IEmailTemplateViewTemplateService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        public ActionResult Details()
        {
            return PartialView();
        }

        public JsonResult GetDetails(Guid id)
        {
            EmailTemplateViewTemplate template = service.GetById(id);
            return Json(template, JsonRequestBehavior.AllowGet);
        }
    }
}
