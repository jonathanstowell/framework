using System;
using System.Web.Mvc;
using ThreeBytes.Core.Data.ResultSets.Abstract;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Logging.Exceptions.List.Entities;
using ThreeBytes.Logging.Exceptions.List.Frontend.Models;
using ThreeBytes.Logging.Exceptions.List.Service.Abstract;

namespace ThreeBytes.Logging.Exceptions.List.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Admin", "LoggingAccess" })]
    public class ExceptionListController : StatelessSessionController
    {
        private readonly IExceptionListService service;

        public ExceptionListController(IExceptionListService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        [HttpGet]
        public ActionResult List(int? page, DateTime? datetime)
        {
            IPagedResult<ExceptionList> roles = service.GetAllPaged(10, datetime, page ?? 1);
            IMostRecentResult<ExceptionList> mostRecentEmails = null;

            if (datetime.HasValue)
            {
                mostRecentEmails = service.GetLatestSince((DateTime)datetime);
            }

            if (Request.IsAjaxRequest())
                return Json(roles, JsonRequestBehavior.AllowGet);

            return PartialView(new PagedExceptionListViewModel(roles, mostRecentEmails));
        }

        [HttpGet]
        public JsonResult GetNewerThan(DateTime datetime)
        {
            IMostRecentResult<ExceptionList> mostRecentRoles = service.GetLatestSince(datetime);
            return Json(mostRecentRoles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Get(Guid id)
        {
            ExceptionList item = service.GetById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
    }
}
