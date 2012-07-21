using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Foursquare.Abstract;
using ThreeBytes.Core.Security.Utilities.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Frontend.Commands;
using ThreeBytes.User.Authentication.OAuth.Frontend.Models;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Frontend.Controllers
{
    public class FoursquareController : StatelessSessionController
    {
        private readonly IOAuthUserService service;
        private readonly IProvideUserConfiguration configuration;
        private readonly IFoursquareClient foursquareClient;
        private readonly IThreeBytesTicketService ticketService;
        private readonly Func<FoursquareLoginCommand> foursquareLoginCommandAccessor;

        public FoursquareController(IProvideUserConfiguration configuration, Func<FoursquareLoginCommand> foursquareLoginCommandAccessor, IThreeBytesTicketService ticketService, IFoursquareClient foursquareClient, IOAuthUserService service)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");

            this.configuration = configuration;
            this.foursquareLoginCommandAccessor = foursquareLoginCommandAccessor;
            this.ticketService = ticketService;
            this.foursquareClient = foursquareClient;
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
                { "state", GetAbsoluteUrlAsString(configuration.RedirectAction, configuration.RedirectController) }
            };

            string redirect = foursquareClient.GetLoginUrl(GetAbsoluteUrlAsString("Callback", "Foursquare"), parameters);

            return Redirect(redirect);
        }

        [HttpGet]
        public ActionResult LinkAccount(string redirectUrl)
        {
            var parameters = new Dictionary<string, object> { 
                { "state", redirectUrl }
            };

            string redirect = foursquareClient.GetLoginUrl(GetAbsoluteUrlAsString("Callback", "Foursquare"), parameters);

            return Redirect(redirect);
        }

        public ActionResult Callback(string code, string state)
        {
            var foursquareLoginCommand = foursquareLoginCommandAccessor();

            foursquareLoginCommand.Code = code;
            foursquareLoginCommand.Path = Url.Action("Callback", "Foursquare");
            foursquareLoginCommand.Url = Request.Url;

            foursquareLoginCommand.Execute();

            if (foursquareLoginCommand.Success)
            {
                CreateEncodedAuthenticationTicket(foursquareLoginCommand.Identifier, foursquareLoginCommand.Username, foursquareLoginCommand.Roles, foursquareLoginCommand.ExternalProvider.ToString());

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