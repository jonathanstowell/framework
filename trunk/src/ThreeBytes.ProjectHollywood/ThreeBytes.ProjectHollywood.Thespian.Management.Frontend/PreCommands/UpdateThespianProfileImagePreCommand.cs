using System;
using FluentValidation.Results;
using NServiceBus;
using SignalR;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;
using ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.Hubs;
using ThreeBytes.ProjectHollywood.Thespian.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Messages.Commands;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.PreCommands
{
    public class UpdateThespianProfileImagePreCommand : ICommand
    {
        public IBus Bus { get; set; }
        public IConnectionManager ConnectionManager;
        public ValidationResult Results { get; set; }

        public Guid Id { get; set; }
        public string NewProfileImageLocation { get; set; }
        public string NewProfileThumbnailImageLocation { get; set; }
        public string UpdatedBy { get; set; }

        private readonly IThespianManagementThespianService service;
        private readonly IThespianManagementThespianValidatorResolver validatorResolver;
        private bool executed;

        public UpdateThespianProfileImagePreCommand(IConnectionManager connectionManager, IThespianManagementThespianService service, IThespianManagementThespianValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            ConnectionManager = connectionManager;

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IUpdateThespianProfileImageCommandMessage>(x => { x.Id = Id; x.NewProfileImageLocation = NewProfileImageLocation; x.NewProfileThumbnailImageLocation = NewProfileThumbnailImageLocation; x.UpdatedBy = UpdatedBy; });
                ConnectionManager.GetClients<ThespianManagementHub>().handleThespianProfileImageUpdatedEventMessage(Id, NewProfileImageLocation, NewProfileThumbnailImageLocation);
            }
        }

        public void Validate()
        {
            ThespianManagementThespian employee = service.GetById(Id);

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