using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities;
using ThreeBytes.ProjectHollywood.Thespian.List.Entities.Enums;
using ThreeBytes.ProjectHollywood.Thespian.List.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.List.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Backend.MessageHandlers
{
    public class ThespianCreatedEventMessageHandler : IHandleMessages<ICreatedThespianInternalEventMessage>
    {
        private readonly IThespianListThespianService service;
        private readonly IThespianListThespianValidatorResolver validatorResolver;

        public ThespianCreatedEventMessageHandler(IThespianListThespianService service, IThespianListThespianValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ICreatedThespianInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ThespianListThespian thespian = new ThespianListThespian
                                       {
                                           Id = message.Id,
                                           FirstName = message.FirstName,
                                           LastName = message.LastName,
                                           ProfileImageLocation = message.ProfileImageLocation,
                                           ProfileThumbnailImageLocation = message.ProfileThumbnailImageLocation,
                                           Gender = (Gender)Enum.Parse(typeof(Gender), message.Gender),
                                           ThespianType = (ThespianType)Enum.Parse(typeof(ThespianType), message.ThespianType),
                                           CreatedBy = message.CreatedBy
                                       };

            ValidationResult result = validatorResolver.CreateValidator().Validate(thespian);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Thespian", result);
            }

            service.Create(thespian);
        }
    }
}
