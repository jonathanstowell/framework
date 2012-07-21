using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;
using ThreeBytes.ProjectHollywood.Thespian.View.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.View.Validations.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Backend.MessageHandlers
{
    public class DeletedThespianInternalEventMessageHandler : IHandleMessages<IDeletedThespianInternalEventMessage>
    {
        private readonly IThespianViewThespianService service;
        private readonly IThespianViewThespianValidatorResolver validatorResolver;

        public DeletedThespianInternalEventMessageHandler(IThespianViewThespianService service, IThespianViewThespianValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IDeletedThespianInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ThespianViewThespian thespian = service.GetById(message.Id);

            if (thespian == null)
                return;

            ValidationResult result = validatorResolver.DeleteValidator().Validate(thespian);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not delete Thespian", result);
            }

            service.Delete(thespian);
        }
    }
}
