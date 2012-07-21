using System;
using System.Collections.Generic;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Email.Messages.ExternalCommands;
using ThreeBytes.User.Authentication.Messages.InternalEvents;

namespace ThreeBytes.User.Authentication.Email.Backend.MessageHandlers
{
    public class ResetPasswordConfirmedInternalEventMessageHandler : IHandleMessages<IResetPasswordConfirmedInternalEventMessage>
    {
        public IBus Bus { get; set; }

        public void Handle(IResetPasswordConfirmedInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            Dictionary<string, string> model = new Dictionary<string, string>();

            model.Add("Username", message.Username);

            Bus.PublishAndSendLocal<ISendTemplatedEmailExternalCommandMessage>(x =>
            {
                x.ApplicationName = message.ApplicationName;
                x.TemplateName = "ResetPasswordConfirmed";
                x.To = message.Email;
                x.Model = model;
            });
        }
    }
}
