using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Email.Template.Management.Entities;
using ThreeBytes.Email.Template.Management.Entities.Enums;
using ThreeBytes.Email.Template.Management.Validations.Abstract;
using ThreeBytes.Email.Template.Messages.Commands;

namespace ThreeBytes.Email.Template.Management.Frontend.PreCommands
{
    public class CreateTemplatePreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        private readonly IEmailTemplateManagementTemplateValidatorResolver validatorResolver;
        public ValidationResult Results { get; set; }

        private bool executed;

        public CreateTemplatePreCommand(IEmailTemplateManagementTemplateValidatorResolver validatorResolver)
        {
            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.validatorResolver = validatorResolver;
        }

        public string Name { get; set; }
        public string ApplicationName { get; set; }
        public string From { get; set; }
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
                Bus.Send<ICreateTemplateCommandMessage>(x =>
                {
                    x.Name = Name;
                    x.ApplicationName = ApplicationName;
                    x.From = From;
                    x.Subject = Subject;
                    x.Body = Body;
                    x.IsHtml = IsHtml;
                    x.Encoding = Encoding.ToString();
                });
            }
        }

        public void Validate()
        {
            EmailTemplateManagementTemplate template = new EmailTemplateManagementTemplate
                                                           {
                                                               Name = Name,
                                                               ApplicationName = ApplicationName,
                                                               From = From,
                                                               Subject = Subject,
                                                               Body = Body,
                                                               IsHtml = IsHtml,
                                                               Encoding = Encoding
                                                           };


            Results = validatorResolver.CreateValidator().Validate(template);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
