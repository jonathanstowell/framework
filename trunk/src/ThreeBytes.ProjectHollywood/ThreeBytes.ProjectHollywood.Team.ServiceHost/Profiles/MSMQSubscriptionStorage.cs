﻿using NServiceBus;

namespace ThreeBytes.ProjectHollywood.Team.ServiceHost.Profiles
{
    public class MSMQSubscriptionStorage : IProfile
    { }

    public class MSMQSubscriptionStorageProfileHandler : IHandleProfile<MSMQSubscriptionStorage>
    {
        public void ProfileActivated()
        {
            Configure.Instance.MsmqSubscriptionStorage();
        }
    }
}
