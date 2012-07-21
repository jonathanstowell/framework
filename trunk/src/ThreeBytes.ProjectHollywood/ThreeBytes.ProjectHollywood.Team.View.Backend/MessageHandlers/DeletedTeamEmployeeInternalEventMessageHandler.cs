using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Team.View.Entities;
using ThreeBytes.ProjectHollywood.Team.View.Service.Abstract;
using ThreeBytes.ProjectHollywood.Team.View.Validations.Abstract;

namespace ThreeBytes.ProjectHollywood.Team.View.Backend.MessageHandlers
{
    public class DeletedTeamEmployeeInternalEventMessageHandler : IHandleMessages<IDeletedTeamEmployeeInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamViewEmployeeService service;
        private readonly ITeamViewEmployeeValidatorResolver validatorResolver;

        public DeletedTeamEmployeeInternalEventMessageHandler(ITeamViewEmployeeService service, ITeamViewEmployeeValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IDeletedTeamEmployeeInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            TeamViewEmployee employee = service.GetById(message.Id);

            if (employee == null)
                return;

            ValidationResult result = validatorResolver.DeleteValidator().Validate(employee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not delete Employee", result);
            }

            service.Delete(employee);
        }
    }
}
