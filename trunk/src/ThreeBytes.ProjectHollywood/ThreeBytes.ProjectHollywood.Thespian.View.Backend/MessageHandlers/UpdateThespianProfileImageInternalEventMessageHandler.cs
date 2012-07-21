using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;
using ThreeBytes.ProjectHollywood.Thespian.View.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.View.Validations.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Backend.MessageHandlers
{
    public class UpdateThespianProfileImageInternalEventMessageHandler : IHandleMessages<IUpdatedThespianProfileImageEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IThespianViewThespianService service;
        private readonly IThespianViewThespianValidatorResolver validatorResolver;

        public UpdateThespianProfileImageInternalEventMessageHandler(IThespianViewThespianService service, IThespianViewThespianValidatorResolver validatorResolver)
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

            ThespianViewThespian oldThespian = service.GetById(message.Id);

            if (oldThespian == null)
                return;

            if (string.Equals(oldThespian.ProfileImageLocation, message.ProfileImageLocation) && string.Equals(oldThespian.ProfileThumbnailImageLocation, message.ProfileThumbnailImageLocation))
                return;

            ThespianViewThespian newThespian = new ThespianViewThespian(oldThespian);

            newThespian.ProfileImageLocation = message.ProfileImageLocation;
            newThespian.ProfileThumbnailImageLocation = message.ProfileThumbnailImageLocation;
            newThespian.LastModifiedBy = message.UpdatedBy;

            ValidationResult result = validatorResolver.UpdateProfileImageValidator().Validate(newThespian);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update Employee Summary", result);
            }

            IHistoricalUpdateOperation<ThespianViewThespian> updateOperation = new HistoricalUpdateOperation<ThespianViewThespian>
            {
                OldItem = oldThespian,
                NewItem = newThespian,
                OperationDescription = string.Format("Updated Profile Image From {0} to {1}", oldThespian.ProfileImageLocation, newThespian.ProfileImageLocation)
            };

            service.Update(updateOperation);
        }
    }
}
