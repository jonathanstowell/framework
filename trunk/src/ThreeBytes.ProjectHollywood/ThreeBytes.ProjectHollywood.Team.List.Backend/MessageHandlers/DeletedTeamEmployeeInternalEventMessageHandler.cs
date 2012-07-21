using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Team.List.Entities;
using ThreeBytes.ProjectHollywood.Team.List.Service.Abstract;
using ThreeBytes.ProjectHollywood.Team.List.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.List.Backend.MessageHandlers
{
    public class DeletedTeamEmployeeInternalEventMessageHandler : IHandleMessages<IDeletedTeamEmployeeInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamListEmployeeService service;
        private readonly ITeamListEmployeeValidatorResolver validatorResolver;

        public DeletedTeamEmployeeInternalEventMessageHandler(ITeamListEmployeeService service, ITeamListEmployeeValidatorResolver validatorResolver)
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

            TeamListEmployee employee = service.GetById(message.Id);

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
