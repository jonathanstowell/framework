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
    public class UpdateTeamEmployeeProfileImagePreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public IConnectionManager ConnectionManager;
        public ValidationResult Results { get; set; }

        public Guid Id { get; set; }
        public string NewProfileImageLocation { get; set; }
        public string NewProfileThumbnailImageLocation { get; set; }
        public string UpdatedBy { get; set; }

        private readonly ITeamManagementEmployeeService service;
        private readonly ITeamManagementEmployeeValidatorResolver validatorResolver;
        private bool executed;

        public UpdateTeamEmployeeProfileImagePreCommand(IConnectionManager connectionManager, ITeamManagementEmployeeValidatorResolver validatorResolver, ITeamManagementEmployeeService service)
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
                Bus.Send<IUpdateTeamEmployeeProfileImageCommandMessage>(x => { x.Id = Id; x.NewProfileImageLocation = NewProfileImageLocation; x.NewProfileThumbnailImageLocation = NewProfileThumbnailImageLocation; x.UpdatedBy = UpdatedBy; });
                ConnectionManager.GetClients<TeamManagementHub>().handleTeamProfileImageUpdatedEventMessage(Id, NewProfileImageLocation, NewProfileThumbnailImageLocation);
            }
        }

        public void Validate()
        {
            TeamManagementEmployee employee = service.GetById(Id);

            if (employee != null)
            {
                employee.ProfileImageLocation = NewProfileImageLocation;
                employee.ProfileThumbnailImageLocation = NewProfileThumbnailImageLocation;
                employee.LastModifiedBy = UpdatedBy;
            }

            Results = validatorResolver.UpdateProfileImageValidator().Validate(employee);
        }

        public bool HasExecuted { get { return executed; } }
    }
}