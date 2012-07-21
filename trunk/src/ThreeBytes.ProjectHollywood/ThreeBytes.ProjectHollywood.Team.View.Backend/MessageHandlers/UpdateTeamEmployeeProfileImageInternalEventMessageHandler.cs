using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.ProjectHollywood.Team.Messages.InternalEvents;
using ThreeBytes.ProjectHollywood.Team.View.Entities;
using ThreeBytes.ProjectHollywood.Team.View.Service.Abstract;
using ThreeBytes.ProjectHollywood.Team.View.Validations.Abstract;

namespace ThreeBytes.ProjectHollywood.Team.View.Backend.MessageHandlers
{
    public class UpdateTeamEmployeeProfileImageInternalEventMessageHandler : IHandleMessages<IUpdatedTeamEmployeeProfileImageEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamViewEmployeeService service;
        private readonly ITeamViewEmployeeValidatorResolver validatorResolver;

        public UpdateTeamEmployeeProfileImageInternalEventMessageHandler(ITeamViewEmployeeService service, ITeamViewEmployeeValidatorResolver validatorResolver)
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

            TeamViewEmployee oldEmployee = service.GetById(message.Id);

            if (oldEmployee == null)
                return;

            if (string.Equals(oldEmployee.ProfileImageLocation, message.ProfileImageLocation) && string.Equals(oldEmployee.ProfileThumbnailImageLocation, message.ProfileThumbnailImageLocation))
                return;

            TeamViewEmployee newEmployee = new TeamViewEmployee(oldEmployee);

            newEmployee.ProfileImageLocation = message.ProfileImageLocation;
            newEmployee.ProfileThumbnailImageLocation = message.ProfileThumbnailImageLocation;
            newEmployee.LastModifiedBy = message.UpdatedBy;

            ValidationResult result = validatorResolver.UpdateProfileImageValidator().Validate(newEmployee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update Employee Summary", result);
            }

            IHistoricalUpdateOperation<TeamViewEmployee> updateOperation = new HistoricalUpdateOperation<TeamViewEmployee>
            {
                OldItem = oldEmployee,
                NewItem = newEmployee,
                OperationDescription = string.Format("Updated Profile Image From {0} to {1}", oldEmployee.ProfileImageLocation, newEmployee.ProfileImageLocation)
            };

            service.Update(updateOperation);
        }
    }
}
