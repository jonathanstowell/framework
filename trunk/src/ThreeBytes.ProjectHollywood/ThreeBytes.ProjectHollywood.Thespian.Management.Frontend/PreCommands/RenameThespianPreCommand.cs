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
    public class RenameThespianPreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public IConnectionManager ConnectionManager;
        public ValidationResult Results { get; set; }

        private readonly IThespianManagementThespianService service;
        private readonly IThespianManagementThespianValidatorResolver validatorResolver;
        private bool executed;

        public RenameThespianPreCommand(IConnectionManager connectionManager, IThespianManagementThespianService service, IThespianManagementThespianValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("_validatorResolver");

            ConnectionManager = connectionManager;

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RenamedBy { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IRenameThespianCommandMessage>(x =>
                {
                    x.Id = Id;
                    x.NewFirstName = FirstName;
                    x.NewLastName = LastName;
                    x.RenamedBy = RenamedBy;
                });

                ConnectionManager.GetClients<ThespianManagementHub>().handleThespianRenamedEventMessage(Id, FirstName, LastName);
            }
        }

        public void Validate()
        {
            ThespianManagementThespian thespian = service.GetById(Id);

            if (thespian != null)
            {
                thespian.FirstName = FirstName;
                thespian.LastName = LastName;
                thespian.LastModifiedBy = RenamedBy;
            }

            Results = validatorResolver.RenameValidator().Validate(thespian);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
