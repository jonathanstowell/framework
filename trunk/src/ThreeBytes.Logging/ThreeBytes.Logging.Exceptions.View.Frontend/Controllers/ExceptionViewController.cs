using System;
using System.Web.Mvc;
using ThreeBytes.Core.Extensions.Web;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Logging.Exceptions.View.Entities;
using ThreeBytes.Logging.Exceptions.View.Service.Abstract;

namespace ThreeBytes.Logging.Exceptions.View.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Admin", "LoggingAccess" })]
    public class ExceptionViewController : StatelessSessionController
    {
        private readonly IExceptionViewService service;

        public ExceptionViewController(IExceptionViewService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
                return PartialView();

            ExceptionView email = service.GetById((Guid)id);

            if (Request.IsAjaxRequest())
                return Json(email, JsonRequestBehavior.AllowGet);

            if (HttpContext.IsMobile())
                return View(email);

            return PartialView(email);
        }
    }
}
