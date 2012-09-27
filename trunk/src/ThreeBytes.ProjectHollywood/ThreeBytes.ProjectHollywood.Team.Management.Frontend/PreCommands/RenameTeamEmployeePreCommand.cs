using System;
using FluentValidation.Results;
using NServiceBus;
using SignalR;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;
using ThreeBytes.ProjectHollywood.Team.Management.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Team.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.Team.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Team.Messages.Commands;

namespace ThreeBytes.ProjectHollywood.Team.Management.Frontend.PreCommands
{
    public class RenameTeamEmployeePreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public IConnectionManager ConnectionManager;
        public ValidationResult Results { get; set; }

        public Guid Id { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
        public string RenamedBy { get; set; }

        private readonly ITeamManagementEmployeeService service;
        private readonly ITeamManagementEmployeeValidatorResolver validatorResolver;
        private bool executed;

        public RenameTeamEmployeePreCommand(IConnectionManager connectionManager, ITeamManagementEmployeeValidatorResolver validatorResolver, ITeamManagementEmployeeService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            ConnectionManager = connectionManager;

            this.validatorResolver = validatorResolver;
            this.service = service;

        }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IRenameTeamEmployeeCommandMessage>(x => { x.Id = Id; x.NewFirstName = NewFirstName; x.NewLastName = NewLastName; x.RenamedBy = RenamedBy; });
                ConnectionManager.GetClients<TeamManagementHub>().handleRenamedTeamEmployeeEventMessage(Id, NewFirstName, NewLastName);
            }
        }

        public void Validate()
        {
            TeamManagementEmployee employee = service.GetById(Id);

            if (employee != null)
            {
                employee.FirstName = NewFirstName;
                employee.LastName = NewLastName;
                employee.LastModifiedBy = RenamedBy;
            }

            Results = validatorResolver.RenameValidator().Validate(employee);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
