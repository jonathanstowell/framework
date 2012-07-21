using System;
using System.Web.Mvc;
using ThreeBytes.Core.Extensions.Validations;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.User.Authentication.Password.Frontend.Models;
using ThreeBytes.User.Authentication.Password.Frontend.PreCommands;

namespace ThreeBytes.User.Authentication.Password.Frontend.Controllers
{
    public class PasswordManagementController : StatelessSessionController
    {
        private readonly Func<ResetPasswordPreCommand> resetPasswordPreCommandAccessor;
        private readonly Func<ResetPasswordConfirmPreCommand> resetPasswordConfirmPreCommandAccessor;

        public PasswordManagementController(Func<ResetPasswordPreCommand> resetPasswordPreCommandAccessor, Func<ResetPasswordConfirmPreCommand> resetPasswordConfirmPreCommandAccessor)
        {
            this.resetPasswordPreCommandAccessor = resetPasswordPreCommandAccessor;
            this.resetPasswordConfirmPreCommandAccessor = resetPasswordConfirmPreCommandAccessor;
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ResetPassword(string userIdentifier)
        {
            if (string.IsNullOrEmpty(userIdentifier) && !Request.IsAjaxRequest())
                return PartialView();

            var resetPasswordPreCommand = resetPasswordPreCommandAccessor();

            resetPasswordPreCommand.UserIdentifier = userIdentifier;
            resetPasswordPreCommand.Execute();

            return Json(resetPasswordPreCommand.Results);
        }

        [HttpGet]
        public ActionResult ResetPasswordConfirm()
        {
            return View(new ResetPasswordConfirmViewModel());
        }

        [HttpPost]
        public ActionResult ResetPasswordConfirm(ResetPasswordConfirmViewModel model)
        {
            var resetPasswordConfirmPreCommand = resetPasswordConfirmPreCommandAccessor();

            resetPasswordConfirmPreCommand.UserIdentifier = model.UserIdentifier;

            if (model.ResetPasswordCode != null)
                resetPasswordConfirmPreCommand.ResetPasswordCode = (Guid)model.ResetPasswordCode;

            resetPasswordConfirmPreCommand.NewPassword = model.Password;
            resetPasswordConfirmPreCommand.NewConfirmPassword = model.ConfirmPassword;

            resetPasswordConfirmPreCommand.Execute();

            if (resetPasswordConfirmPreCommand.Results.IsValid)
            {
                model.Success = true;
                return View(model);
            }

            resetPasswordConfirmPreCommand.Results.CopyTo(ModelState);

            return View(model);
        }
    }
}
