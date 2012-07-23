﻿using System;
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
    public class CreateTeamEmployeeCommandMessageHandler : IHandleMessages<ICreateTeamEmployeeCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly ITeamManagementEmployeeService service;
        private readonly ITeamManagementEmployeeValidatorResolver validatorResolver;

        public CreateTeamEmployeeCommandMessageHandler(ITeamManagementEmployeeService service, ITeamManagementEmployeeValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ICreateTeamEmployeeCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            TeamManagementEmployee employee = new TeamManagementEmployee
                                         {
                                             FirstName = message.FirstName,
                                             LastName = message.LastName,
                                             JobTitle = message.JobTitle,
                                             ProfileImageLocation = message.ProfileImageLocation,
                                             ProfileThumbnailImageLocation = message.ProfileThumbnailImageLocation,
                                             Summary = message.Summary,
                                             CreatedBy = message.CreatedBy
                                         };

            ValidationResult result = validatorResolver.CreateValidator().Validate(employee);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Employee", result);
            }

            service.Create(employee);

            Bus.PublishAndSendLocal<ICreatedTeamEmployeeInternalEventMessage>(x =>
            {
                x.Id = employee.Id;
                x.FirstName = employee.FirstName;
                x.LastName = employee.LastName;
                x.JobTitle = employee.JobTitle;
                x.ProfileImageLocation = employee.ProfileImageLocation;
                x.ProfileThumbnailImageLocation = employee.ProfileThumbnailImageLocation;
                x.Summary = employee.Summary;
                x.CreatedBy = employee.CreatedBy;
                x.EventDescription = string.Format("{0} just added {1} {2} to the team.", employee.CreatedBy, employee.FirstName, employee.LastName);
            });
        }
    }
}