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
    public class UpdateTeamEmployeeSummaryCommandMessageHandler : IHandleMessages<IUpdateTeamEmployeeSummaryCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamManagementEmployeeService service;
        private readonly ITeamManagementEmployeeValidatorResolver validatorResolver;

        public UpdateTeamEmployeeSummaryCommandMessageHandler(ITeamManagementEmployeeService service, ITeamManagementEmployeeValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdateTeamEmployeeSummaryCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            TeamManagementEmployee employee = service.GetById(message.Id);

            if (employee == null)
                return;

            if (string.Equals(employee.Summary, message.NewSummary))
                return;

            employee.Summary = message.NewSummary;
            employee.LastModifiedBy = message.UpdatedBy;

            ValidationResult result = validatorResolver.UpdateSummaryValidator().Validate(employee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update Employee Summary", result);
            }

            service.Update(employee);

            Bus.PublishAndSendLocal<IUpdatedTeamEmployeeSummaryInternalEventMessage>(x =>
            {
                x.Id = employee.Id;
                x.NewSummary = employee.Summary;
                x.UpdatedBy = employee.LastModifiedBy;
                x.EventDescription = string.Format("{0} updated {1} {2} summary.", employee.LastModifiedBy, employee.FirstName, employee.LastName);
            });
        }
    }
}
