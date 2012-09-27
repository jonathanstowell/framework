using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Email.Template.Management.Entities;
using ThreeBytes.Email.Template.Management.Entities.Enums;
using ThreeBytes.Email.Template.Management.Service.Abstract;
using ThreeBytes.Email.Template.Management.Validations.Abstract;
using ThreeBytes.Email.Template.Messages.Commands;

namespace ThreeBytes.Email.Template.Management.Frontend.PreCommands
{
    public class UpdateTemplateEmailContentsPreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        private readonly IEmailTemplateManagementTemplateValidatorResolver validatorResolver;
        public ValidationResult Results { get; set; }

        private readonly IEmailTemplateManagementTemplateService service;
        private bool executed;

        public UpdateTemplateEmailContentsPreCommand(IEmailTemplateManagementTemplateValidatorResolver validatorResolver, IEmailTemplateManagementTemplateService service)
        {
            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
        public Encoding Encoding { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IUpdateTemplateEmailContentsCommandMessage>(x =>
                {
                    x.Id = Id;
                    x.Subject = Subject;
                    x.Body = Body;
                    x.IsHtml = IsHtml;
                    x.Encoding = Encoding.ToString();
                });
            }
        }

        public void Validate()
        {
            EmailTemplateManagementTemplate template = service.GetById(Id);
            template.Subject = Subject;
            template.Body = Body;
            template.IsHtml = IsHtml;
            template.Encoding = Encoding;
            Results = validatorResolver.UpdateContentsValidator().Validate(template);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
