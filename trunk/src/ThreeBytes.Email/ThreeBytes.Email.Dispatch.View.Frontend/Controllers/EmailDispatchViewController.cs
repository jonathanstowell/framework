using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Dispatch.View.Entities;
using ThreeBytes.Email.Dispatch.View.Service.Abstract;

namespace ThreeBytes.Email.Dispatch.View.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class EmailDispatchViewController : StatelessSessionController
    {
        private readonly IEmailDispatchViewEmailMessageService service;

        public EmailDispatchViewController(IEmailDispatchViewEmailMessageService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        public ActionResult Details(Guid? id)
        {
            return PartialView();
        }

        public JsonResult GetDetails(Guid id)
        {
            EmailDispatchViewEmailMessage users = service.GetById(id);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}
