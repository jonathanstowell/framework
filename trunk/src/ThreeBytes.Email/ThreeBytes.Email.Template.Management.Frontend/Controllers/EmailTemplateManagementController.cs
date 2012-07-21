using System;
using System.Web.Mvc;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Configuration.Abstract;
using ThreeBytes.Email.Template.Management.Entities;
using ThreeBytes.Email.Template.Management.Entities.Enums;
using ThreeBytes.Email.Template.Management.Frontend.PreCommands;
using ThreeBytes.Email.Template.Management.Service.Abstract;

namespace ThreeBytes.Email.Template.Management.Frontend.Controllers
{
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "EmailTemplateManager" })]
    public class EmailTemplateManagementController : StatelessSessionController
    {
        private readonly IEmailTemplateManagementTemplateService service;
        private readonly IProvideEmailConfiguration configuration;

        private readonly Func<CreateTemplatePreCommand> createTemplatePreCommandAccessor;
        private readonly Func<DeletedTemplatePreCommand> deletedTemplatePreCommandAccessor;
        private readonly Func<RenameTemplatePreCommand> renameTemplatePreCommandAccessor;
        private readonly Func<UpdateTemplateFromEmailAddressPreCommand> updateTemplateFromEmailAddressPreCommandAccessor;
        private readonly Func<UpdateTemplateEmailContentsPreCommand> updateTemplateEmailContentsPreCommandAccessor;

        public EmailTemplateManagementController(IEmailTemplateManagementTemplateService service, IProvideEmailConfiguration configuration, Func<CreateTemplatePreCommand> createTemplatePreCommandAccessor, Func<DeletedTemplatePreCommand> deletedTemplatePreCommandAccessor, Func<RenameTemplatePreCommand> renameTemplatePreCommandAccessor, Func<UpdateTemplateFromEmailAddressPreCommand> updateTemplateFromEmailAddressPreCommandAccessor, Func<UpdateTemplateEmailContentsPreCommand> updateTemplateEmailContentsPreCommandAccessor)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;

            this.configuration = configuration;
            this.createTemplatePreCommandAccessor = createTemplatePreCommandAccessor;
            this.deletedTemplatePreCommandAccessor = deletedTemplatePreCommandAccessor;
            this.renameTemplatePreCommandAccessor = renameTemplatePreCommandAccessor;
            this.updateTemplateFromEmailAddressPreCommandAccessor = updateTemplateFromEmailAddressPreCommandAccessor;
            this.updateTemplateEmailContentsPreCommandAccessor = updateTemplateEmailContentsPreCommandAccessor;
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(EmailTemplateManagementTemplate template)
        {
            var createTemplatePreCommand = createTemplatePreCommandAccessor();

            createTemplatePreCommand.Name = template.Name;
            createTemplatePreCommand.ApplicationName = configuration.ApplicationName;
            createTemplatePreCommand.From = template.From;
            createTemplatePreCommand.Subject = template.Subject;
            createTemplatePreCommand.Body = template.Body;
            createTemplatePreCommand.IsHtml = template.IsHtml;
            createTemplatePreCommand.Encoding = template.Encoding;

            createTemplatePreCommand.Execute();

            return Json(createTemplatePreCommand.Results);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return PartialView("Edit");
        }

        [HttpPost]
        public ActionResult RenameName(Guid id, string name)
        {
            var renameTemplatePreCommand = renameTemplatePreCommandAccessor();

            renameTemplatePreCommand.Id = id;
            renameTemplatePreCommand.Name = name;

            renameTemplatePreCommand.Execute();

            return Json(renameTemplatePreCommand.Results);
        }

        [HttpPost]
        public ActionResult RenameFrom(Guid id, string from)
        {
            var updateTemplateFromEmailAddressPreCommand = updateTemplateFromEmailAddressPreCommandAccessor();

            updateTemplateFromEmailAddressPreCommand.Id = id;
            updateTemplateFromEmailAddressPreCommand.From = from;

            updateTemplateFromEmailAddressPreCommand.Execute();

            return Json(updateTemplateFromEmailAddressPreCommand.Results);
        }

        [HttpPost]
        public ActionResult UpdateContent(Guid id, string subject, string body, bool isHtml, Encoding encoding)
        {
            var updateTemplateEmailContentsPreCommand = updateTemplateEmailContentsPreCommandAccessor();

            updateTemplateEmailContentsPreCommand.Id = id;
            updateTemplateEmailContentsPreCommand.Subject = subject;
            updateTemplateEmailContentsPreCommand.Body = body;
            updateTemplateEmailContentsPreCommand.IsHtml = isHtml;
            updateTemplateEmailContentsPreCommand.Encoding = encoding;

            updateTemplateEmailContentsPreCommand.Execute();

            return Json(updateTemplateEmailContentsPreCommand.Results);
        }

        public ActionResult Delete()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var deletedTemplatePreCommand = deletedTemplatePreCommandAccessor();

            deletedTemplatePreCommand.Id = id;
            deletedTemplatePreCommand.Execute();

            return Json(deletedTemplatePreCommand.Results);
        }

        [HttpGet]
        public JsonResult GetTemplateForUpdateOrDelete(Guid id)
        {
            EmailTemplateManagementTemplate template = service.GetById(id);
            return Json(template, JsonRequestBehavior.AllowGet);
        }
    }
}
