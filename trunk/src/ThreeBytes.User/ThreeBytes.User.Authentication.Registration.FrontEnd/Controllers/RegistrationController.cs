using System;
using System.Web.Mvc;
using ThreeBytes.Core.Extensions.Validations;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.FrontEnd.Models;
using ThreeBytes.User.Authentication.Registration.FrontEnd.PreCommands;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Registration.FrontEnd.Controllers
{
    public class RegistrationController : StatelessSessionController
    {
        private readonly IExternalUserService externalUserService;
        private readonly IProvideUserConfiguration configuration;

        private readonly Func<RegisterUserPreCommand> registerUserPreCommandAccessor;
        private readonly Func<RegisterExistingUserPreCommand> registerExistingUserPreCommandAccessor;
        private readonly Func<VerifyAccountPreCommand> verifyAccountPreCommandAccessor;

        public RegistrationController(Func<RegisterUserPreCommand> registerUserPreCommandAccessor, Func<VerifyAccountPreCommand> verifyAccountPreCommandAccessor, IExternalUserService externalUserService, IProvideUserConfiguration configuration, Func<RegisterExistingUserPreCommand> registerExistingUserPreCommandAccessor)
        {
            this.registerUserPreCommandAccessor = registerUserPreCommandAccessor;
            this.verifyAccountPreCommandAccessor = verifyAccountPreCommandAccessor;
            this.externalUserService = externalUserService;
            this.configuration = configuration;
            this.registerExistingUserPreCommandAccessor = registerExistingUserPreCommandAccessor;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        public ActionResult PartialRegister()
        {
            return PartialView(new RegisterViewModel());
        }

        [HttpGet]
        public ActionResult RegisterExisting(string username, string email)
        {
            ExternalUser user = externalUserService.GetUserByEmail(email, configuration.ApplicationName);
            return View(new RegisterExistingViewModel(username, email, user));
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            var registerUserPreCommand = registerUserPreCommandAccessor();

            registerUserPreCommand.UserName = model.UserName;
            registerUserPreCommand.Email = model.Email;
            registerUserPreCommand.Password = model.Password;
            registerUserPreCommand.ConfirmPassword = model.ConfirmPassword;

            registerUserPreCommand.Execute();

            if (registerUserPreCommand.AlreadyHasAnAccountUsingAnExternalProvider)
                return RedirectToAction("RegisterExisting", new { username = model.UserName, email = model.Email });

            if (registerUserPreCommand.Results.IsValid)
                model.Success = true;

            registerUserPreCommand.Results.CopyTo(ModelState);

            return View(model);
        }

        [HttpPost]
        public ActionResult RegisterExisting(RegisterExistingViewModel model)
        {
            var registerUserPreCommand = registerExistingUserPreCommandAccessor();

            registerUserPreCommand.UserName = model.UserName;
            registerUserPreCommand.Email = model.Email;
            registerUserPreCommand.Password = model.Password;
            registerUserPreCommand.ConfirmPassword = model.ConfirmPassword;

            registerUserPreCommand.Execute();

            if (registerUserPreCommand.Results.IsValid)
                model.Success = true;

            registerUserPreCommand.Results.CopyTo(ModelState);

            return View(model);
        }

        [HttpGet]
        public ActionResult VerifyAccount(string userIdentifier, Guid? verifyCode)
        {
            return View(new VerifyAccountViewModel { UserIdentifier = userIdentifier, VerifiedCode = verifyCode });
        }

        [HttpPost]
        public ActionResult VerifyAccount(VerifyAccountViewModel model)
        {
            var verifyAccountPreCommand = verifyAccountPreCommandAccessor();

            verifyAccountPreCommand.UserIdentifier = model.UserIdentifier;
            verifyAccountPreCommand.VerifiedCode = model.VerifiedCode ?? Guid.Empty;

            verifyAccountPreCommand.Execute();

            if (verifyAccountPreCommand.Results.IsValid)
                model.Success = true;
            else
                verifyAccountPreCommand.Results.CopyTo(ModelState);

            return View(model);
        }
    }
}
