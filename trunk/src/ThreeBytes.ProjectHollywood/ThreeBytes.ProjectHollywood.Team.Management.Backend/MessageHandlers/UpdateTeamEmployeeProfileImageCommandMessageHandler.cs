using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;
using ThreeBytes.ProjectHollywood.Team.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.Team.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Team.Messages.Commands;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Team.Management.Backend.MessageHandlers
{
    public class UpdateTeamEmployeeProfileImageCommandMessageHandler : IHandleMessages<IUpdateTeamEmployeeProfileImageCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamManagementEmployeeService service;
        private readonly ITeamManagementEmployeeValidatorResolver validatorResolver;

        public UpdateTeamEmployeeProfileImageCommandMessageHandler(ITeamManagementEmployeeService service, ITeamManagementEmployeeValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdateTeamEmployeeProfileImageCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            TeamManagementEmployee employee = service.GetById(message.Id);

            if (employee == null)
                return;

            if (string.Equals(employee.ProfileImageLocation, message.NewProfileImageLocation) && string.Equals(employee.ProfileThumbnailImageLocation, message.NewProfileThumbnailImageLocation))
                return;

            employee.ProfileImageLocation = message.NewProfileImageLocation;
            employee.ProfileThumbnailImageLocation = message.NewProfileThumbnailImageLocation;
            employee.LastModifiedBy = message.UpdatedBy;

            ValidationResult result = validatorResolver.UpdateProfileImageValidator().Validate(employee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update Employee Profile Image", result);
            }

            service.Update(employee);

            Bus.PublishAndSendLocal<IUpdatedTeamEmployeeProfileImageEventMessage>(x =>
            {
                x.Id = employee.Id;
                x.ProfileImageLocation = employee.ProfileImageLocation;
                x.ProfileThumbnailImageLocation = employee.ProfileThumbnailImageLocation;
                x.UpdatedBy = employee.LastModifiedBy;
                x.EventDescription = string.Format("{0} updated {1} {2} profile image.", employee.LastModifiedBy, employee.FirstName, employee.LastName);
            });
        }
    }
}
