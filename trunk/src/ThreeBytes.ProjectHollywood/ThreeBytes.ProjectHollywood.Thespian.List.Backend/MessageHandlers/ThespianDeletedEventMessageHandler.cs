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
    public class ThespianDeletedEventMessageHandler : IHandleMessages<IDeletedThespianInternalEventMessage>
    {
        private readonly IThespianListThespianService service;
        private readonly IThespianListThespianValidatorResolver validatorResolver;

        public ThespianDeletedEventMessageHandler(IThespianListThespianService service, IThespianListThespianValidatorResolver validatorResolver)
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

            ThespianListThespian thespian = service.GetById(message.Id);

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
