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
    public class DeleteThespianCommandMessageHandler : IHandleMessages<IDeleteThespianCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IThespianManagementThespianService service;
        private readonly IThespianManagementThespianValidatorResolver _validatorResolver;

        public DeleteThespianCommandMessageHandler(IThespianManagementThespianService service, IThespianManagementThespianValidatorResolver _validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (_validatorResolver == null)
                throw new ArgumentNullException("_validatorResolver");

            this.service = service;
            this._validatorResolver = _validatorResolver;
        }

        public void Handle(IDeleteThespianCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ThespianManagementThespian thespian = service.GetById(message.Id);

            if (thespian == null)
                return;

            ValidationResult result = _validatorResolver.DeleteValidator().Validate(thespian);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not delete Thespian", result);
            }

            service.Delete(thespian);

            Bus.PublishAndSendLocal<IDeletedThespianInternalEventMessage>(x =>
                                                       {
                                                           x.Id = message.Id;
                                                           x.DeletedBy = message.DeletedBy;
                                                           x.EventDescription = string.Format("{0} deleted the thespian {1} {2}.", message.DeletedBy, thespian.FirstName, thespian.LastName);
                                                       });
        }
    }
}
