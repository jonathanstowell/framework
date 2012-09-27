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
    public class DeletedTemplatePreCommand : IPreCommand
    {
        public IBus Bus { get; set; }

        private readonly IEmailTemplateManagementTemplateService service;
        private readonly IEmailTemplateManagementTemplateValidatorResolver validatorResolver;

        public ValidationResult Results { get; set; }

        private bool executed;

        public DeletedTemplatePreCommand(IEmailTemplateManagementTemplateValidatorResolver validatorResolver, IEmailTemplateManagementTemplateService service)
        {
            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            if (service == null)
                throw new ArgumentNullException("service");

            this.validatorResolver = validatorResolver;
            this.service = service;
        }

        public Guid Id { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IDeleteTemplateCommandMessage>(x =>
                {
                    x.Id = Id;
                });
            }
        }

        public void Validate()
        {
            EmailTemplateManagementTemplate template = service.GetById(Id);
            Results = validatorResolver.DeleteValidator().Validate(template);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
