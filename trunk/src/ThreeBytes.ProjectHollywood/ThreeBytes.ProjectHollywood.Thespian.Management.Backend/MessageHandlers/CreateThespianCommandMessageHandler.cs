using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities.Enums;
using ThreeBytes.ProjectHollywood.Thespian.Management.Service.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Messages.Commands;
using ThreeBytes.ProjectHollywood.Thespian.Messages.InternalEvents;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Backend.MessageHandlers
{
    public class CreateThespianCommandMessageHandler : IHandleMessages<ICreateThespianCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IThespianManagementThespianService service;
        private readonly IThespianManagementThespianValidatorResolver _validatorResolver;

        public CreateThespianCommandMessageHandler(IThespianManagementThespianService service, IThespianManagementThespianValidatorResolver _validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (_validatorResolver == null)
                throw new ArgumentNullException("_validatorResolver");

            this.service = service;
            this._validatorResolver = _validatorResolver;
        }

        public void Handle(ICreateThespianCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ThespianManagementThespian thespian = new ThespianManagementThespian
                                         {
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

            Bus.PublishAndSendLocal<ICreatedThespianInternalEventMessage>(x =>
                                                                   {
                                                                       x.Id = thespian.Id;
                                                                       x.FirstName = thespian.FirstName;
                                                                       x.LastName = thespian.LastName;
                                                                       x.ProfileImageLocation = thespian.ProfileImageLocation;
                                                                       x.ProfileThumbnailImageLocation = thespian.ProfileThumbnailImageLocation;
                                                                       x.DateOfBirth = thespian.DateOfBirth;
                                                                       x.Email = thespian.Email;
                                                                       x.Gender = thespian.Gender.ToString();
                                                                       x.Location = thespian.Location;
                                                                       x.Height = thespian.Height;
                                                                       x.Weight = thespian.Weight;
                                                                       x.PlayingAge = thespian.PlayingAge;
                                                                       x.EyeColour = thespian.EyeColour.ToString();
                                                                       x.HairLength = thespian.HairLength.ToString();
                                                                       x.Summary = thespian.Summary;
                                                                       x.Twitter = thespian.Twitter;
                                                                       x.Facebook = thespian.Facebook;
                                                                       x.Spotlight = thespian.Spotlight;
                                                                       x.Imdb = thespian.Imdb;
                                                                       x.ThespianType = thespian.ThespianType.ToString();
                                                                       x.CreatedBy = thespian.CreatedBy;
                                                                       x.EventDescription = string.Format("{0} created the thespian {1} {2}.", thespian.CreatedBy, thespian.FirstName, thespian.LastName);
                                                                   });
        }
    }
}
