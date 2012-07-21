using System;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;

namespace ThreeBytes.User.Authentication.UserView.Backend.MessageHandlers
{
    public class LockOutUserInternalEventMessageHandler : IHandleMessages<ILockUserOutInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IAuthenticationUserViewUserService service;

        public LockOutUserInternalEventMessageHandler(IAuthenticationUserViewUserService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
        }

        public void Handle(ILockUserOutInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            AuthenticationUserViewUser oldAuthenticationUser = service.GetById(message.Id);

            if (oldAuthenticationUser == null)
                return;

            if (oldAuthenticationUser.IsLockedOut)
                return;

            AuthenticationUserViewUser newAuthenticationUser = new AuthenticationUserViewUser(oldAuthenticationUser);

            newAuthenticationUser.IsLockedOut = false;

            IHistoricalUpdateOperation<AuthenticationUserViewUser> updateOperation = new HistoricalUpdateOperation<AuthenticationUserViewUser>
            {
                OldItem = oldAuthenticationUser,
                NewItem = newAuthenticationUser,
                OperationDescription = "Locked Account."
            };

            service.Update(updateOperation);
        }
    }
}
