using System;
using NServiceBus;
using ThreeBytes.Core.Email.Abstract;
using ThreeBytes.Core.Email.Exceptions;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Email.Dispatch.Management.Entities;
using ThreeBytes.Email.Dispatch.Management.Service.Abstract;
using ThreeBytes.Email.Dispatch.Messages.InternalEvents;
using ThreeBytes.Email.Dispatch.Management.Entities.Enums;
using ThreeBytes.Email.Messages.ExternalCommands;

namespace ThreeBytes.Email.Dispatch.Management.Backend.MessageHandlers
{
    public class SendTemplatedEmailEventMessageHandler : IHandleMessages<ISendTemplatedEmailExternalCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailDispatchManagementTemplateService service;
        private readonly IEmailDispatcher emailDispatcher;
        private readonly ITemplateEngine templateEngine;

        public SendTemplatedEmailEventMessageHandler(IEmailDispatchManagementTemplateService service, IEmailDispatcher emailDispatcher, ITemplateEngine templateEngine)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (emailDispatcher == null)
                throw new ArgumentNullException("emailDispatcher");

            if (templateEngine == null)
                throw new ArgumentNullException("templateEngine");

            this.service = service;
            this.templateEngine = templateEngine;
            this.emailDispatcher = emailDispatcher;
        }

        public void Handle(ISendTemplatedEmailExternalCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailDispatchManagementTemplate template = service.GetBy(message.TemplateName, message.ApplicationName);

            if (template == null)
                template = service.GetBy(message.TemplateName, "Generic");

            if (template == null)
                return;
            
            var mail = new EmailDispatchManagementEmailMessage();

            mail.ApplicationName = template.ApplicationName;
            mail.Subject = template.Subject;
            mail.Body = templateEngine.GetTemplatedBody(template.Body, message.Model);
            mail.From = template.From;
            mail.To = message.To;
            mail.CC = message.CC;
            mail.BCC = message.BCC;
            mail.IsHtml = template.IsHtml;
            mail.Encoding = Encoding.ASCII;

            ISendEmailResult result = emailDispatcher.Dispatch(mail);

            if (result.Success)
            {
                Bus.PublishAndSendLocal<ISentEmailMessageEventMessage>(x =>
                {
                    x.Id = Guid.NewGuid();
                    x.ApplicationName = mail.ApplicationName;
                    x.From = mail.From;
                    x.To = mail.To;
                    x.CC = mail.CC;
                    x.BCC = mail.BCC;
                    x.Subject = mail.Subject;
                    x.Body = mail.Body;
                    x.IsHtml = mail.IsHtml;
                    x.Encoding = mail.Encoding.ToString();
                });
            }
            else
            {
                throw new AsyncServiceEmailException("Could not send email", result);
            }
        }
    }
}
