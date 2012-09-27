using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Email.Template.Management.Entities;
using ThreeBytes.Email.Template.Management.Service.Abstract;
using ThreeBytes.Email.Template.Management.Validations.Abstract;
using ThreeBytes.Email.Template.Messages.Commands;

namespace ThreeBytes.Email.Template.Management.Frontend.PreCommands
{
    public class UpdateTemplateFromEmailAddressPreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        private readonly IEmailTemplateManagementTemplateValidatorResolver validatorResolver;
        public ValidationResult Results { get; set; }

        private readonly IEmailTemplateManagementTemplateService service;
        private bool executed;

        public UpdateTemplateFromEmailAddressPreCommand(IEmailTemplateManagementTemplateValidatorResolver validatorResolver, IEmailTemplateManagementTemplateService service)
        {
            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public Guid Id { get; set; }
        public string From { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IUpdateTemplateFromEmailAddressCommandMessage>(x =>
                {
                    x.Id = Id;
                    x.From = From;
                });
            }
        }

        public void Validate()
        {
            EmailTemplateManagementTemplate template = service.GetById(Id);
            template.From = From;
            Results = validatorResolver.UpdateFromAddressValidator().Validate(template);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
