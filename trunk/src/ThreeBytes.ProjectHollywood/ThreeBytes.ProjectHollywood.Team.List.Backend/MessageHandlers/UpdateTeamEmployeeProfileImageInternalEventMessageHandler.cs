using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Team.List.Entities;
using ThreeBytes.ProjectHollywood.Team.List.Service.Abstract;
using ThreeBytes.ProjectHollywood.Team.List.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Team.Messages.Commands;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.List.Backend.MessageHandlers
{
    public class UpdateTeamEmployeeProfileImageInternalEventMessageHandler : IHandleMessages<IUpdatedTeamEmployeeProfileImageEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamListEmployeeService service;
        private readonly ITeamListEmployeeValidatorResolver validatorResolver;

        public UpdateTeamEmployeeProfileImageInternalEventMessageHandler(ITeamListEmployeeService service, ITeamListEmployeeValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdatedTeamEmployeeProfileImageEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            TeamListEmployee employee = service.GetById(message.Id);

            if (employee == null)
                return;

            if (string.Equals(employee.ProfileImageLocation, message.ProfileImageLocation) && string.Equals(employee.ProfileThumbnailImageLocation, message.ProfileThumbnailImageLocation))
                return;

            employee.ProfileImageLocation = message.ProfileImageLocation;
            employee.ProfileThumbnailImageLocation = message.ProfileThumbnailImageLocation;
            employee.LastModifiedBy = message.UpdatedBy;

            ValidationResult result = validatorResolver.UpdateProfileImageValidator().Validate(employee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update Employee Profile Image", result);
            }

            service.Update(employee);
        }
    }
}
