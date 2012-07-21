using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Core.Upload.Abstract;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;
using ThreeBytes.ProjectHollywood.Team.Management.Validations.Abstract;
using ThreeBytes.ProjectHollywood.Team.Messages.Commands;

namespace ThreeBytes.ProjectHollywood.Team.Management.Frontend.PreCommands
{
    public class CreateTeamEmployeePreCommand : ICommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string ProfileImageLocation { get; set; }
        public string ProfileThumbnailImageLocation { get; set; }
        public string Summary { get; set; }
        public string CreatedBy { get; set; }

        private readonly ITeamManagementEmployeeValidatorResolver validatorResolver;
        private readonly IFileStore fileStore;
        private bool executed;

        public CreateTeamEmployeePreCommand(ITeamManagementEmployeeValidatorResolver validatorResolver, IFileStore fileStore)
        {
            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.validatorResolver = validatorResolver;
            this.fileStore = fileStore;
        }

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

                Bus.Send<ICreateTeamEmployeeCommandMessage>(x =>
                                                                {
                                                                    x.FirstName = FirstName;
                                                                    x.LastName = LastName;
                                                                    x.JobTitle = JobTitle;
                                                                    x.ProfileImageLocation = ProfileImageLocation;
                                                                    x.ProfileThumbnailImageLocation = ProfileThumbnailImageLocation;
                                                                    x.Summary = Summary;
                                                                    x.CreatedBy = CreatedBy;
                                                                });
            }
        }

        public void Validate()
        {
            TeamManagementEmployee employee = new TeamManagementEmployee
                                                  {
                                                      FirstName = FirstName,
                                                      LastName = LastName,
                                                      JobTitle = JobTitle,
                                                      ProfileImageLocation = ProfileImageLocation,
                                                      ProfileThumbnailImageLocation = ProfileThumbnailImageLocation,
                                                      Summary = Summary,
                                                      CreatedBy = CreatedBy
                                                  };

            Results = validatorResolver.CreateValidator().Validate(employee);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
