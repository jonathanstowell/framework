using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;
using ThreeBytes.ProjectHollywood.Thespian.List.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.List.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Backend.MessageHandlers
{
    public class UpdateThespianProfileImageInternalEventMessageHandler : IHandleMessages<IUpdatedThespianProfileImageEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IThespianListThespianService service;
        private readonly IThespianListThespianValidatorResolver validatorResolver;

        public UpdateThespianProfileImageInternalEventMessageHandler(IThespianListThespianService service, IThespianListThespianValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdatedThespianProfileImageEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ThespianListThespian employee = service.GetById(message.Id);

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
                throw new AsyncServiceValidationException("Could not update Thespian Profile Image", result);
            }

            service.Update(employee);
        }
    }
}
