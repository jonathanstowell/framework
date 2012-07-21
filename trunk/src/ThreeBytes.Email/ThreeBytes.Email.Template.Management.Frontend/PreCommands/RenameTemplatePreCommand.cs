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
    public class RenameTemplatePreCommand : ICommand
    {
        public IBus Bus { get; set; }
        private readonly IEmailTemplateManagementTemplateValidatorResolver validatorResolver;
        public ValidationResult Results { get; set; }

        private readonly IEmailTemplateManagementTemplateService service;
        private bool executed;

        public RenameTemplatePreCommand(IEmailTemplateManagementTemplateValidatorResolver validatorResolver, IEmailTemplateManagementTemplateService service)
        {
            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IRenameTemplateCommandMessage>(x =>
                {
                    x.Id = Id;
                    x.Name = Name;
                });
            }
        }

        public void Validate()
        {
            EmailTemplateManagementTemplate template = service.GetById(Id);
            template.Name = Name;
            Results = validatorResolver.RenameValidator().Validate(template);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
