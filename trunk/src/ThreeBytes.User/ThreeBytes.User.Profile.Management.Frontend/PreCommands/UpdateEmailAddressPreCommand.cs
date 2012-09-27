using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.User.Profile.Management.Entities;
using ThreeBytes.User.Profile.Management.Service.Abstract;
using ThreeBytes.User.Profile.Management.Validations.Abstract;
using ThreeBytes.User.Profile.Messages.Commands;

namespace ThreeBytes.User.Profile.Management.Frontend.PreCommands
{
    public class UpdateEmailAddressPreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        private readonly IProfileManagementProfileValidatorResolver validatorResolver;
        private readonly IProfileManagementProfileService service;
        private bool executed;

        public UpdateEmailAddressPreCommand(IProfileManagementProfileService service, IProfileManagementProfileValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public Guid Id { get; set; }
        public string NewEmail { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IUpdateProfileEmailAddressCommandMessage>(x =>
                {
                    x.Id = Id;
                    x.NewEmail = NewEmail;
                });
            }
        }

        public void Validate()
        {
            UserProfileManagementProfile profile = service.GetById(Id);
            
            if (profile != null)
                profile.Email = NewEmail;

            Results = validatorResolver.UpdateEmailAddressValidator().Validate(profile);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
