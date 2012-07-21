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
    public class RenameJobTitlePreCommand : ICommand
    {
        public IBus Bus { get; set; }
        public IConnectionManager ConnectionManager;
        public ValidationResult Results { get; set; }

        public Guid Id { get; set; }
        public string NewJobTitle { get; set; }
        public string RenamedBy { get; set; }

        private readonly ITeamManagementEmployeeService service;
        private readonly ITeamManagementEmployeeValidatorResolver validatorResolver;
        private bool executed;

        public RenameJobTitlePreCommand(IConnectionManager connectionManager, ITeamManagementEmployeeValidatorResolver validatorResolver, ITeamManagementEmployeeService service)
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
                Bus.Send<IRenameTeamEmployeeJobTitleCommandMessage>(x => { x.Id = Id; x.NewJobTitle = NewJobTitle; x.RenamedBy = RenamedBy; });
                ConnectionManager.GetClients<TeamManagementHub>().handleRenamedTeamEmployeeJobTitleEventMessage(Id, NewJobTitle);
            }
        }

        public void Validate()
        {
            TeamManagementEmployee employee = service.GetById(Id);

            if (employee != null)
            {
                employee.JobTitle = NewJobTitle;
                employee.LastModifiedBy = RenamedBy;
            }

            Results = validatorResolver.RenameJobValidator().Validate(employee);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
