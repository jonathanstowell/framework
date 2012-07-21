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
    public class RenamedTeamEmployeeInternalEventMessageHandler : IHandleMessages<IRenamedTeamEmployeeInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamListEmployeeService service;
        private readonly ITeamListEmployeeValidatorResolver validatorResolver;

        public RenamedTeamEmployeeInternalEventMessageHandler(ITeamListEmployeeService service, ITeamListEmployeeValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRenamedTeamEmployeeInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            TeamListEmployee employee = service.GetById(message.Id);

            if (employee == null)
                return;

            if (string.Equals(employee.FirstName, message.NewFirstName) && string.Equals(employee.LastName, message.NewLastName))
                return;

            if (!string.Equals(employee.FirstName, message.NewFirstName))
                employee.FirstName = message.NewFirstName;

            if (!string.Equals(employee.LastName, message.NewLastName))
                employee.LastName = message.NewLastName;

            ValidationResult result = validatorResolver.RenameValidator().Validate(employee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not rename Employee", result);
            }

            service.Update(employee);
        }
    }
}
