using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Logging.Exceptions.Widget.Entities;
using ThreeBytes.Logging.Exceptions.Widget.Service.Abstract;

namespace ThreeBytes.Logging.Exceptions.Widget.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Admin", "LoggingAccess" })]
    public class ExceptionWidgetController : StatelessSessionController
    {
        private readonly IExceptionWidgetService service;

        public ExceptionWidgetController(IExceptionWidgetService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        [HttpGet]
        public ActionResult MostRecent()
        {
            IList<ExceptionWidget> emails = service.GetMostRecent(10);

            if (Request.IsAjaxRequest())
                return Json(new { Items = emails }, JsonRequestBehavior.AllowGet);

            return PartialView(emails);
        }
    }
}
