using System;
using FluentValidation;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.Management.Entities;
using ThreeBytes.Email.Template.Management.Entities.Enums;
using ThreeBytes.Email.Template.Management.Service.Abstract;
using ThreeBytes.Email.Template.Management.Validations.Abstract;
using ThreeBytes.Email.Template.Messages.Commands;
using ThreeBytes.Email.Template.Messages.InternalEvents;

namespace ThreeBytes.Email.Template.Management.Backend.MessageHandlers
{
    public class CreatedTemplateCommandMessageHandler : IHandleMessages<ICreateTemplateCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailTemplateManagementTemplateService service;
        private readonly IEmailTemplateManagementTemplateValidatorResolver validatorResolver;

        public CreatedTemplateCommandMessageHandler(IEmailTemplateManagementTemplateService service, IEmailTemplateManagementTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ICreateTemplateCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailTemplateManagementTemplate template = new EmailTemplateManagementTemplate
            {
                Name = message.Name,
                ApplicationName = message.ApplicationName,
                Encoding = (Encoding)Enum.Parse(typeof(Encoding), message.Encoding),
                From = message.From,
                IsHtml = message.IsHtml,
                Subject = message.Subject,
                Body = message.Body
            };

            ValidationResult result = validatorResolver.CreateValidator().Validate(template);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add Template", result);
            }

            service.Create(template);

            Bus.PublishAndSendLocal<ICreatedTemplateInternalEventMessage>(x =>
            {
                x.Id = template.Id;
                x.Name = template.Name;
                x.ApplicationName = template.ApplicationName;
                x.Encoding = template.Encoding.ToString();
                x.From = template.From;
                x.IsHtml = template.IsHtml;
                x.Subject = template.Subject;
                x.Body = template.Body;
            });
        }
    }
}
