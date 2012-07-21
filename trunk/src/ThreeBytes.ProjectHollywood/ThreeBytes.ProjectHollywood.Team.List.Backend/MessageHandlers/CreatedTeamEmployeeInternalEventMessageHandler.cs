using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Team.List.Entities;
using ThreeBytes.ProjectHollywood.Team.List.Service.Abstract;
using ThreeBytes.ProjectHollywood.Team.List.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.List.Backend.MessageHandlers
{
    public class CreatedTeamEmployeeInternalEventMessageHandler : IHandleMessages<ICreatedTeamEmployeeInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamListEmployeeService service;
        private readonly ITeamListEmployeeValidatorResolver validatorResolver;

        public CreatedTeamEmployeeInternalEventMessageHandler(ITeamListEmployeeService service, ITeamListEmployeeValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ICreatedTeamEmployeeInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            TeamListEmployee employee = new TeamListEmployee
                                         {
                                             Id = message.Id,
                                             FirstName = message.FirstName,
                                             LastName = message.LastName,
                                             JobTitle = message.JobTitle,
                                             ProfileImageLocation = message.ProfileImageLocation,
                                             ProfileThumbnailImageLocation = message.ProfileThumbnailImageLocation,
                                             CreatedBy = message.CreatedBy
                                         };

            ValidationResult result = validatorResolver.CreateValidator().Validate(employee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Employee", result);
            }

            service.Create(employee);
        }
    }
}
