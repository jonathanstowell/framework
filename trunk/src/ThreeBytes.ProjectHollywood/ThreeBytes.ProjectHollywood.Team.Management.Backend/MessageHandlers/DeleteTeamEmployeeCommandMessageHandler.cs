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
    public class DeleteTeamEmployeeCommandMessageHandler : IHandleMessages<IDeleteTeamEmployeeCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamManagementEmployeeService service;
        private readonly ITeamManagementEmployeeValidatorResolver validatorResolver;

        public DeleteTeamEmployeeCommandMessageHandler(ITeamManagementEmployeeService service, ITeamManagementEmployeeValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IDeleteTeamEmployeeCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            TeamManagementEmployee employee = service.GetById(message.Id);

            if (employee == null)
                return;

            ValidationResult result = validatorResolver.DeleteValidator().Validate(employee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not delete Employee", result);
            }

            service.Delete(employee);

            Bus.PublishAndSendLocal<IDeletedTeamEmployeeInternalEventMessage>(x =>
                                                       {
                                                           x.Id = employee.Id;
                                                           x.DeletedBy = message.DeletedBy;
                                                           x.EventDescription = string.Format("{0} just added {1} {2} to the team.", message.DeletedBy, employee.FirstName, employee.LastName);
                                                       });
        }
    }
}
