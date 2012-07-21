using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Team.View.Entities;
using ThreeBytes.ProjectHollywood.Team.View.Service.Abstract;
using ThreeBytes.ProjectHollywood.Team.View.Validations.Abstract;

namespace ThreeBytes.ProjectHollywood.Team.View.Backend.MessageHandlers
{
    public class RenamedTeamEmployeeInternalEventMessageHandler : IHandleMessages<IRenamedTeamEmployeeInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamViewEmployeeService service;
        private readonly ITeamViewEmployeeValidatorResolver validatorResolver;

        public RenamedTeamEmployeeInternalEventMessageHandler(ITeamViewEmployeeService service, ITeamViewEmployeeValidatorResolver validatorResolver)
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

            TeamViewEmployee oldEmployee = service.GetById(message.Id);

            if (oldEmployee == null)
                return;

            if (string.Equals(oldEmployee.FirstName, message.NewFirstName) && string.Equals(oldEmployee.LastName, message.NewLastName))
                return;

            TeamViewEmployee newEmployee = new TeamViewEmployee(oldEmployee);

            if (!string.Equals(newEmployee.FirstName, message.NewFirstName))
                newEmployee.FirstName = message.NewFirstName;

            if (!string.Equals(newEmployee.LastName, message.NewLastName))
                newEmployee.LastName = message.NewLastName;

            ValidationResult result = validatorResolver.RenameValidator().Validate(newEmployee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not rename Employee", result);
            }

            IHistoricalUpdateOperation<TeamViewEmployee> updateOperation = new HistoricalUpdateOperation<TeamViewEmployee>
            {
                OldItem = oldEmployee,
                NewItem = newEmployee,
                OperationDescription = string.Format("Renamed From {0} {1} to {2} {3}", oldEmployee.FirstName, oldEmployee.LastName, newEmployee.FirstName, newEmployee.LastName)
            };

            service.Update(updateOperation);
        }
    }
}
