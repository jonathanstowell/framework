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
    public class DeleteTeamEmployeePreCommand : ICommand
    {
        public IBus Bus { get; set; }
        public IConnectionManager ConnectionManager;
        public ValidationResult Results { get; set; }

        private readonly ITeamManagementEmployeeService service;
        private readonly ITeamManagementEmployeeValidatorResolver validatorResolver;
        private bool executed;

        public DeleteTeamEmployeePreCommand(IConnectionManager connectionManager, ITeamManagementEmployeeService service, ITeamManagementEmployeeValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            ConnectionManager = connectionManager;

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public Guid Id { get; set; }
        public string DeletedBy { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IDeleteTeamEmployeeCommandMessage>(x => { x.Id = Id; x.DeletedBy = DeletedBy; });
                ConnectionManager.GetClients<TeamManagementHub>().handleDeletedTeamEmployeeEventMessage(Id);
            }
        }

        public void Validate()
        {
            TeamManagementEmployee employee = service.GetById(Id);

            if (employee != null)
                employee.LastModifiedBy = DeletedBy;

            Results = validatorResolver.DeleteValidator().Validate(employee);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
