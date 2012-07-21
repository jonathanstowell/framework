using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;
using ThreeBytes.ProjectHollywood.Thespian.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Messages.Commands;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Backend.MessageHandlers
{
    public class UpdateTeamEmployeeProfileImageCommandMessageHandler : IHandleMessages<IUpdateThespianProfileImageCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IThespianManagementThespianService service;
        private readonly IThespianManagementThespianValidatorResolver validatorResolver;

        public UpdateTeamEmployeeProfileImageCommandMessageHandler(IThespianManagementThespianService service, IThespianManagementThespianValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdateThespianProfileImageCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ThespianManagementThespian thespian = service.GetById(message.Id);

            if (thespian == null)
                return;

            if (string.Equals(thespian.ProfileImageLocation, message.NewProfileImageLocation) && string.Equals(thespian.ProfileThumbnailImageLocation, message.NewProfileThumbnailImageLocation))
                return;

            thespian.ProfileImageLocation = message.NewProfileImageLocation;
            thespian.ProfileThumbnailImageLocation = message.NewProfileThumbnailImageLocation;
            thespian.LastModifiedBy = message.UpdatedBy;

            ValidationResult result = validatorResolver.UpdateProfileImageValidator().Validate(thespian);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update Employee Profile Image", result);
            }

            service.Update(thespian);

            Bus.PublishAndSendLocal<IUpdatedThespianProfileImageEventMessage>(x =>
            {
                x.Id = thespian.Id;
                x.ProfileImageLocation = thespian.ProfileImageLocation;
                x.ProfileThumbnailImageLocation = thespian.ProfileThumbnailImageLocation;
                x.UpdatedBy = thespian.LastModifiedBy;
                x.EventDescription = string.Format("{0} updated {1} {2} profile image.", thespian.LastModifiedBy, thespian.FirstName, thespian.LastName);
            });
        }
    }
}
