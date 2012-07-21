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
    public class RenameTeamEmployeeJobTitleCommandMessageHandler : IHandleMessages<IRenameTeamEmployeeJobTitleCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamManagementEmployeeService service;
        private readonly ITeamManagementEmployeeValidatorResolver validatorResolver;

        public RenameTeamEmployeeJobTitleCommandMessageHandler(ITeamManagementEmployeeService service, ITeamManagementEmployeeValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRenameTeamEmployeeJobTitleCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            TeamManagementEmployee employee = service.GetById(message.Id);

            if (employee == null)
                return;

            if (string.Equals(employee.JobTitle, message.NewJobTitle))
                return;

            string oldJobTitle = employee.JobTitle;

            employee.JobTitle = message.NewJobTitle;
            employee.LastModifiedBy = message.RenamedBy;

            ValidationResult result = validatorResolver.RenameJobValidator().Validate(employee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not rename Employee job title", result);
            }

            service.Update(employee);

            Bus.PublishAndSendLocal<IRenamedTeamEmployeeJobTitleInternalEventMessage>(x =>
            {
                x.Id = employee.Id;
                x.NewJobTitle = employee.JobTitle;
                x.RenamedBy = employee.LastModifiedBy;
                x.EventDescription = string.Format("{0} just changed {1} {2} job title from {3} to {4}.", employee.LastModifiedBy, employee.FirstName, employee.LastName, oldJobTitle, employee.JobTitle);
            });
        }
    }
}
