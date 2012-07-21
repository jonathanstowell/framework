using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;
using ThreeBytes.ProjectHollywood.Team.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.Team.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Team.Messages.Commands;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.Management.Backend.MessageHandlers
{
    public class RenameTeamEmployeeCommandMessageHandler : IHandleMessages<IRenameTeamEmployeeCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamManagementEmployeeService service;
        private readonly ITeamManagementEmployeeValidatorResolver validatorResolver;

        public RenameTeamEmployeeCommandMessageHandler(ITeamManagementEmployeeService service, ITeamManagementEmployeeValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRenameTeamEmployeeCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            TeamManagementEmployee employee = service.GetById(message.Id);

            if (employee == null)
                return;

            if (string.Equals(employee.FirstName, message.NewFirstName) && string.Equals(employee.LastName, message.NewLastName))
                return;

            string oldFirstName = employee.FirstName;

            if (!string.Equals(employee.FirstName, message.NewFirstName))
                employee.FirstName = message.NewFirstName;

            string oldLastName = employee.LastName;

            if (!string.Equals(employee.LastName, message.NewLastName))
                employee.LastName = message.NewLastName;

            employee.LastModifiedBy = message.RenamedBy;

            ValidationResult result = validatorResolver.RenameValidator().Validate(employee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not rename Employee", result);
            }

            service.Update(employee);

            Bus.PublishAndSendLocal<IRenamedTeamEmployeeInternalEventMessage>(x =>
            {
                x.Id = employee.Id;
                x.NewFirstName = employee.FirstName;
                x.NewLastName = employee.LastName;
                x.RenamedBy = employee.LastModifiedBy;
                x.EventDescription = string.Format("{0} just renamed team member {1} {2} to {3} {4}.", employee.LastModifiedBy, oldFirstName, oldLastName, employee.FirstName, employee.LastName);
            });
        }
    }
}
