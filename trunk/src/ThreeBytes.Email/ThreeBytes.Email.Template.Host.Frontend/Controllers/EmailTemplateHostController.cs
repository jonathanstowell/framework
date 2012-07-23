﻿using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;

namespace ThreeBytes.Email.Template.Host.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailAccess" })]
    public class EmailTemplateHostController : StatelessSessionController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}