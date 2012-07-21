using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Facebook.Abstract;
using ThreeBytes.Core.Security.Utilities.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Frontend.Commands;
using ThreeBytes.User.Authentication.OAuth.Frontend.Models;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Frontend.Controllers
{
    public class FacebookController : StatelessSessionController
    {
        private readonly IOAuthUserService service;
        private readonly IProvideUserConfiguration configuration;
        private readonly IThreeBytesTicketService ticketService;
        private readonly IFacebookClient facebookClient;
        private readonly Func<FacebookLoginCommand> facebookLoginCommandAccessor;

        public FacebookController(IProvideUserConfiguration configuration, Func<FacebookLoginCommand> facebookLoginCommandAccessor, IThreeBytesTicketService ticketService, IFacebookClient facebookClient, IOAuthUserService service)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");

            this.configuration = configuration;
            this.facebookLoginCommandAccessor = facebookLoginCommandAccessor;
            this.ticketService = ticketService;
            this.facebookClient = facebookClient;
            this.service = service;
        }

        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult Dropdown()
        {
            return PartialView();
        }

        public ActionResult Link()
        {
            return PartialView();
        }

        public ActionResult Login()
        {
            var parameters = new Dictionary<string, object> { 
                { "state", GetAbsoluteUrlAsString(configuration.RedirectAction, configuration.RedirectController) },
                { "scope", "email" } 
            };

            string redirect = facebookClient.GetLoginUrl(GetAbsoluteUrlAsString("Callback", "Facebook"), parameters);

            return Redirect(redirect);
        }

        [HttpGet]
        public ActionResult LinkAccount(string redirectUrl)
        {
            var parameters = new Dictionary<string, object> { 
                { "state", redirectUrl },
                { "scope", "email" } 
            };

            string redirect = facebookClient.GetLoginUrl(GetAbsoluteUrlAsString("Callback", "Facebook"), parameters);

            return Redirect(redirect);
        }

        public ActionResult Callback(string code, string state)
        {
            var facebookLoginCommand = facebookLoginCommandAccessor();

            facebookLoginCommand.Code = code;
            facebookLoginCommand.Path = Url.Action("Callback", "Facebook");
            facebookLoginCommand.Url = Request.Url;

            facebookLoginCommand.Execute();

            if (facebookLoginCommand.Success)
            {
                CreateEncodedAuthenticationTicket(facebookLoginCommand.Identifier, facebookLoginCommand.Username, facebookLoginCommand.Roles, facebookLoginCommand.ExternalProvider.ToString());

                if (Url.IsLocalUrl(state))
                {
                    return Redirect(state);
                }

                return RedirectToAction(configuration.RedirectAction, configuration.RedirectController);
            }

            return RedirectToAction("Index", "Home");
        }

        public JsonResult GetDetails(Guid id)
        {
            OAuthUser user = service.GetById(id);
            return Json(new LinkViewModel(user), JsonRequestBehavior.AllowGet);
        }

        private void CreateEncodedAuthenticationTicket(Guid id, string username, string roles, string extAuthType = "")
        {
            Response.Cookies.Add(ticketService.GetHttpCookie(id, username, roles, extAuthType));
        }
    }
}
