using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using SignalR.Infrastructure;

namespace ThreeBytes.Core.SignalR.Windsor
{
    public class WindsorDependencyResolver : DefaultDependencyResolver
    {
        private readonly IWindsorContainer container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.container = container;
        }

        public override object GetService(Type serviceType)
        {
            if (serviceType == (Type)null)
                return null;

            try
            {
                return container.Kernel.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Cast<object>(container.ResolveAll(serviceType));
        }
    }
}
