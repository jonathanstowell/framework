using System;
using System.Collections.Generic;
using System.Linq;
using SignalR.Hubs;

namespace ThreeBytes.Core.SignalR.Windsor
{
    public class WindsorHubLocator : IHubLocator
    {
        private readonly IEnumerable<IHub> hubs;

        public WindsorHubLocator(IEnumerable<IHub> hubs)
        {
            this.hubs = hubs;
        }

        public IEnumerable<Type> GetHubs()
        {
            return hubs.Select(x => x.GetType());
        }
    }
}
