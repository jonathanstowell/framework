using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Twitter.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Frontend.Commands;
using ThreeBytes.User.Authentication.OAuth.Frontend.Models;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Frontend.Controllers
{
    public class TwitterController : StatelessSessionController
    {
        private readonly IOAuthUserService service;
        private readonly IProvideUserConfiguration configuration;
        private readonly ITwitterClient twitterClient;
        private readonly Func<TwitterLoginCommand> twitterLoginCommandAccessor;

        public TwitterController(IProvideUserConfiguration configuration, Func<TwitterLoginCommand> twitterLoginCommandAccessor, ITwitterClient twitterClient, IOAuthUserService service)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");

            this.configuration = configuration;
            this.twitterLoginCommandAccessor = twitterLoginCommandAccessor;
            this.twitterClient = twitterClient;
            this.service = service;
        }

        public ActionResult Link()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult LinkAccount(string redirectUrl)
        {
            var parameters = new Dictionary<string, object> { 
                                                                { "state", redirectUrl }
                                                            };

            string redirect = twitterClient.GetLoginUrl(GetAbsoluteUrlAsString("Callback", "Twitter"), parameters);

            return Redirect(redirect);
        }

        public ActionResult Callback(string state, string oauth_token, string oauth_verifier)
        {
            var command = twitterLoginCommandAccessor();

            command.OAuthToken = oauth_token;
            command.OAuthVerifier = oauth_verifier;
            command.Path = Url.Action("Callback", "Twitter");
            command.Url = Request.Url;

            command.Execute();

            if (command.Success)
            {
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
    }
}