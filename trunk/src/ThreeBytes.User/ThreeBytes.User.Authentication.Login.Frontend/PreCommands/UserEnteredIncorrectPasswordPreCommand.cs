using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;
using ThreeBytes.User.Authentication.Login.Validations.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;

namespace ThreeBytes.User.Authentication.Login.Frontend.PreCommands
{
    public class UserEnteredIncorrectPasswordPreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        private readonly ILoginUserService service;
        private readonly ILoginUserValidatorResolver validatorResolver;
        private bool executed;

        public UserEnteredIncorrectPasswordPreCommand(ILoginUserValidatorResolver validatorResolver, ILoginUserService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.validatorResolver = validatorResolver;
            this.service = service;
        }

        public Guid UserId { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IUserEnteredIncorrectPasswordCommandMessage>(x =>
                {
                    x.Id = UserId;
                });
            }
        }

        public void Validate()
        {
            LoginUser user = service.GetById(UserId);
            Results = validatorResolver.UserEnteredIncorrectPasswordValidator().Validate(user);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
