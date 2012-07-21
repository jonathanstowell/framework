using System;
using FluentValidation;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;
using ThreeBytes.ProjectHollywood.Thespian.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Messages.Commands;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Backend.MessageHandlers
{
    public class RenameThespianCommandMessageHandler : IHandleMessages<IRenameThespianCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IThespianManagementThespianService service;
        private readonly IThespianManagementThespianValidatorResolver validatorResolver;

        public RenameThespianCommandMessageHandler(IThespianManagementThespianService service, IThespianManagementThespianValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRenameThespianCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ThespianManagementThespian thespian = service.GetById(message.Id);

            if (thespian == null)
                return;

            if (string.Equals(thespian.FirstName, message.NewFirstName) && string.Equals(thespian.LastName, message.NewLastName))
                return;

            string oldFirstName = thespian.FirstName;

            if (!string.Equals(thespian.FirstName, message.NewFirstName))
                thespian.FirstName = message.NewFirstName;

            string oldLastName = thespian.LastName;

            if (!string.Equals(thespian.LastName, message.NewLastName))
                thespian.LastName = message.NewLastName;

            thespian.LastModifiedBy = message.RenamedBy;

            ValidationResult result = validatorResolver.RenameValidator().Validate(thespian);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not rename Thespian", result);
            }

            service.Update(thespian);

            Bus.PublishAndSendLocal<IRenamedThespianInternalEventMessage>(x =>
            {
                x.Id = thespian.Id;
                x.NewFirstName = thespian.FirstName;
                x.NewLastName = thespian.LastName;
                x.RenamedBy = thespian.LastModifiedBy;
                x.EventDescription = string.Format("{0} renamed thespian from {1} {2} to {3} {4}.", thespian.LastModifiedBy, oldFirstName, oldLastName, thespian.FirstName, thespian.LastName);
            });
        }
    }
}
