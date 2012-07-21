using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities;
using ThreeBytes.ProjectHollywood.Thespian.View.Entities.Enums;
using ThreeBytes.ProjectHollywood.Thespian.View.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.View.Validations.Abstract;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Backend.MessageHandlers
{
    public class CreatedThespianInternalEventMessageHandler : IHandleMessages<ICreatedThespianInternalEventMessage>
    {
        private readonly IThespianViewThespianService service;
        private readonly IThespianViewThespianValidatorResolver _validatorResolver;

        public CreatedThespianInternalEventMessageHandler(IThespianViewThespianService service, IThespianViewThespianValidatorResolver _validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (_validatorResolver == null)
                throw new ArgumentNullException("_validatorResolver");

            this.service = service;
            this._validatorResolver = _validatorResolver;
        }

        public void Handle(ICreatedThespianInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ThespianViewThespian thespian = new ThespianViewThespian
            {
                ItemId = message.Id,
                FirstName = message.FirstName,
                LastName = message.LastName,
                ProfileImageLocation = message.ProfileImageLocation,
                ProfileThumbnailImageLocation = message.ProfileThumbnailImageLocation,
                DateOfBirth = message.DateOfBirth,
                Email = message.Email,
                Gender = (Gender)Enum.Parse(typeof(Gender), message.Gender),
                Location = message.Location,
                Height = message.Height,
                Weight = message.Weight,
                PlayingAge = message.PlayingAge,
                EyeColour = (EyeColour)Enum.Parse(typeof(EyeColour), message.EyeColour),
                HairLength = (HairLength)Enum.Parse(typeof(HairLength), message.HairLength),
                Summary = message.Summary,
                Twitter = message.Twitter,
                Facebook = message.Facebook,
                Spotlight = message.Spotlight,
                Imdb = message.Imdb,
                ThespianType = (ThespianType)Enum.Parse(typeof(ThespianType), message.ThespianType),
                CreatedBy = message.CreatedBy
            };

            ValidationResult result = _validatorResolver.CreateValidator().Validate(thespian);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Thespian", result);
            }

            service.Create(thespian);
        }
    }
}
