using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;
using ThreeBytes.ProjectHollywood.Thespian.View.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.View.Validations.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Backend.MessageHandlers
{
    public class RenamedThespianInternalEventMessageHandler : IHandleMessages<IRenamedThespianInternalEventMessage>
    {
        private readonly IThespianViewThespianService service;
        private readonly IThespianViewThespianValidatorResolver validatorResolver;

        public RenamedThespianInternalEventMessageHandler(IThespianViewThespianService service, IThespianViewThespianValidatorResolver validatorResolver)
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

            ThespianViewThespian oldThespian = service.GetById(message.Id);

            if (oldThespian == null)
                return;

            if (string.Equals(oldThespian.FirstName, message.NewFirstName) && string.Equals(oldThespian.LastName, message.NewLastName))
                return;

            ThespianViewThespian newThespian = new ThespianViewThespian(oldThespian);

            if (!string.Equals(newThespian.FirstName, message.NewFirstName))
                newThespian.FirstName = message.NewFirstName;

            if (!string.Equals(newThespian.LastName, message.NewLastName))
                newThespian.LastName = message.NewLastName;

            ValidationResult result = validatorResolver.RenameValidator().Validate(newThespian);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not rename Thespian", result);
            }

            IHistoricalUpdateOperation<ThespianViewThespian> updateOperation = new HistoricalUpdateOperation<ThespianViewThespian>
            {
                OldItem = oldThespian,
                NewItem = newThespian,
                OperationDescription = string.Format("Renamed From {0} {1} to {2} {3}", oldThespian.FirstName, oldThespian.LastName, newThespian.FirstName, newThespian.LastName)
            };

            service.Update(updateOperation);
        }
    }
}
