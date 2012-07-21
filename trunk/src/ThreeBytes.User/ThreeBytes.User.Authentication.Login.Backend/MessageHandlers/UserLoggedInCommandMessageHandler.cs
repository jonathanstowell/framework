﻿using System;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.Messages.InternalEvents;

namespace ThreeBytes.User.Authentication.Login.Backend.MessageHandlers
{
    public class UserLoggedInCommandMessageHandler : IHandleMessages<IUserLoggedInCommandMessage>
    {
        public IBus Bus { get; set; }

        public void Handle(IUserLoggedInCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            Bus.PublishAndSendLocal<IUserLoggedInInternalEventMessage>(x =>
            {
                x.UserId = message.UserId;
                x.Username = message.Username;
                x.ApplicationName = message.ApplicationName;
                x.LoginDate = message.LoginDate;
            });
        }
    }
}
