using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Team.View.Entities;
using ThreeBytes.ProjectHollywood.Team.View.Service.Abstract;
using ThreeBytes.ProjectHollywood.Team.View.Validations.Abstract;

namespace ThreeBytes.ProjectHollywood.Team.View.Backend.MessageHandlers
{
    public class CreatedTeamEmployeeInternalEventMessageHandler : IHandleMessages<ICreatedTeamEmployeeInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamViewEmployeeService service;
        private readonly ITeamViewEmployeeValidatorResolver validatorResolver;

        public CreatedTeamEmployeeInternalEventMessageHandler(ITeamViewEmployeeService service, ITeamViewEmployeeValidatorResolver validatorResolver)
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

            TeamViewEmployee employee = new TeamViewEmployee
                                         {
                                             ItemId = message.Id,
                                             FirstName = message.FirstName,
                                             LastName = message.LastName,
                                             JobTitle = message.JobTitle,
                                             Summary = message.Summary,
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
