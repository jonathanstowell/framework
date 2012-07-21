using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;
using ThreeBytes.ProjectHollywood.Thespian.List.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.List.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Backend.MessageHandlers
{
    public class ThespianRenamedInternalEventMessageHandler : IHandleMessages<IRenamedThespianInternalEventMessage>
    {
        private readonly IThespianListThespianService service;
        private readonly IThespianListThespianValidatorResolver validatorResolver;

        public ThespianRenamedInternalEventMessageHandler(IThespianListThespianService service, IThespianListThespianValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRenamedThespianInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ThespianListThespian thespian = service.GetById(message.Id);

            if (thespian == null)
                return;

            if (string.Equals(thespian.FirstName, message.NewFirstName) && string.Equals(thespian.LastName, message.NewLastName))
                return;

            if (!string.Equals(thespian.FirstName, message.NewFirstName))
                thespian.FirstName = message.NewFirstName;

            if (!string.Equals(thespian.LastName, message.NewLastName))
                thespian.LastName = message.NewLastName;

            ValidationResult result = validatorResolver.RenameValidator().Validate(thespian);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not rename Thespian", result);
            }

            service.Update(thespian);
        }
    }
}
