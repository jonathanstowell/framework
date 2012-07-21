using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ThreeBytes.Core.Extensions.Validations;
using ThreeBytes.Core.Security.Utilities.Abstract;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Authentication.Login.Configuration.Abstract;
using ThreeBytes.User.Authentication.Login.Frontend.Commands;
using ThreeBytes.User.Authentication.Login.Frontend.Models;
using ThreeBytes.User.Authentication.Login.Frontend.PreCommands;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Login.Frontend.Controllers
{
    public class LoginController : StatelessSessionController
    {
        private readonly IProvideUserConfiguration configuration;
        private readonly IProvideLoginConfiguration loginConfiguration;
        private readonly IThreeBytesTicketService ticketService;
        private readonly Func<LoginUserCommand> loginUserCommandAccessor;
        private readonly Func<UserEnteredIncorrectPasswordPreCommand> userEnteredIncorrectPasswordPreCommandAccessor;

        public LoginController(Func<UserEnteredIncorrectPasswordPreCommand> userEnteredIncorrectPasswordPreCommandAccessor, IProvideLoginConfiguration loginConfiguration, Func<LoginUserCommand> loginUserCommandAccessor, IThreeBytesTicketService ticketService, IProvideUserConfiguration configuration)
        {
            if (userEnteredIncorrectPasswordPreCommandAccessor == null)
                throw new ArgumentNullException("userEnteredIncorrectPasswordPreCommandAccessor");

            if (loginUserCommandAccessor == null)
                throw new ArgumentNullException("loginUserCommandAccessor");

            if (loginConfiguration == null)
                throw new ArgumentNullException("loginConfiguration");

            this.userEnteredIncorrectPasswordPreCommandAccessor = userEnteredIncorrectPasswordPreCommandAccessor;
            this.loginConfiguration = loginConfiguration;
            this.loginUserCommandAccessor = loginUserCommandAccessor;
            this.ticketService = ticketService;
            this.configuration = configuration;
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string controllername, string actionname)
        {
            var loginUserCommand = loginUserCommandAccessor();

            loginUserCommand.UserIdentifier = model.Username;
            loginUserCommand.Password = model.Password;
            
            loginUserCommand.Execute();

            if (loginUserCommand.Results.IsValid)
            {
                CreateEncodedAuthenticationTicket(loginUserCommand.User.Id, loginUserCommand.User.Username, loginUserCommand.User.RolesAsString);

                if (!string.IsNullOrEmpty(actionname) || !string.IsNullOrEmpty(controllername))
                    return RedirectToAction(actionname, controllername);

                return RedirectToAction(configuration.RedirectAction, configuration.RedirectController);
            }

            if (loginUserCommand.Results.Errors.Any(x => x.PropertyName.Equals("Password")))
            {
                var userEnteredIncorrectPasswordPreCommand = userEnteredIncorrectPasswordPreCommandAccessor();

                userEnteredIncorrectPasswordPreCommand.UserId = loginUserCommand.User.Id;
                userEnteredIncorrectPasswordPreCommand.Execute();
            }

            loginUserCommand.Results.CopyTo(ModelState);

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(configuration.RedirectAction, configuration.RedirectController);
        }

        private void CreateEncodedAuthenticationTicket(Guid id, string username, string roles, string extAuthType = "")
        {
            Response.Cookies.Add(ticketService.GetHttpCookie(id, username, roles, extAuthType));
        }
    }
}
