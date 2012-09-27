using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Core.Upload.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities.Enums;
using ThreeBytes.ProjectHollywood.Thespian.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Thespian.Messages.Commands;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.PreCommands
{
    public class CreateThespianPreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        private readonly IThespianManagementThespianValidatorResolver validatorResolver;
        private readonly IFileStore fileStore;

        private bool executed;

        public CreateThespianPreCommand(IThespianManagementThespianValidatorResolver validatorResolver, IFileStore fileStore)
        {
            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.validatorResolver = validatorResolver;
            this.fileStore = fileStore;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageLocation { get; set; }
        public string ProfileThumbnailImageLocation { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Location { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public int? PlayingAge { get; set; }
        public EyeColour EyeColour { get; set; }
        public HairLength HairLength { get; set; }
        public string Summary { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Spotlight { get; set; }
        public string Imdb { get; set; }
        public ThespianType ThespianType { get; set; }
        public string CreatedBy { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                if (!string.IsNullOrEmpty(ProfileImageLocation))
                {
                    bool profileMoveResult = fileStore.MoveTemporaryFileToStored(ProfileImageLocation);

                    if (profileMoveResult == false)
                    {
                        throw new InvalidOperationException("Moving temporary profile image failed.");
                    }
                }

                if (!string.IsNullOrEmpty(ProfileThumbnailImageLocation))
                {
                    bool thumbProfileMoveResult = fileStore.MoveTemporaryFileToStored(ProfileThumbnailImageLocation);

                    if (thumbProfileMoveResult == false)
                    {
                        throw new InvalidOperationException("Moving temporary thumbnail profile image failed.");
                    }
                }

                Bus.Send<ICreateThespianCommandMessage>(x =>
                {
                    x.FirstName = FirstName;
                    x.LastName = LastName;
                    x.ProfileImageLocation = ProfileImageLocation;
                    x.ProfileThumbnailImageLocation = ProfileThumbnailImageLocation;
                    x.DateOfBirth = DateOfBirth;
                    x.Email = Email;
                    x.Gender = Gender.ToString();
                    x.Location = Location;
                    x.Height = Height;
                    x.Weight = Weight;
                    x.PlayingAge = PlayingAge;
                    x.EyeColour = EyeColour.ToString();
                    x.HairLength = HairLength.ToString();
                    x.Summary = Summary;
                    x.Twitter = Twitter;
                    x.Facebook = Facebook;
                    x.Spotlight = Spotlight;
                    x.Imdb = Imdb;
                    x.ThespianType = ThespianType.ToString();
                    x.CreatedBy = CreatedBy;
                });
            }
        }

        public void Validate()
        {
            ThespianManagementThespian thespian = new ThespianManagementThespian
            {
                FirstName = FirstName,
                LastName = LastName,
                ProfileImageLocation = ProfileImageLocation,
                ProfileThumbnailImageLocation = ProfileThumbnailImageLocation,
                DateOfBirth = DateOfBirth,
                Email = Email,
                Gender = Gender,
                Location = Location,
                Height = Height,
                Weight = Weight,
                PlayingAge = PlayingAge,
                EyeColour = EyeColour,
                HairLength = HairLength,
                Summary = Summary,
                Twitter = Twitter,
                Facebook = Facebook,
                Spotlight = Spotlight,
                Imdb = Imdb,
                ThespianType = ThespianType,
                CreatedBy = CreatedBy
            };

            Results = validatorResolver.CreateValidator().Validate(thespian);
        }

        public bool HasExecuted { get { return executed; } }
    }
}