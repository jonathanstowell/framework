using System;
using System.Linq;
using Castle.Windsor;
using ThreeBytes.Core.DataStructures;
using ThreeBytes.Core.Plugin.Navigation.Abstract;
using ThreeBytes.Core.Security.Concrete;

namespace ThreeBytes.Core.Plugin.Navigation.Concrete
{
    public class ProvideNavigation : IProvideNavigationTree
    {
        private readonly IWindsorContainer container;

        public ProvideNavigation(IWindsorContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.container = container;
        }

        public DataStructures.Navigation GetNavigation(ThreeBytesPrincipal principal)
        {
            var result = new DataStructures.Navigation();

            foreach (var nav in container.ResolveAll<IRegisterNavigation>().OrderBy(x => x.Path.Name))
            {
                if (nav.Roles.Length > 0)
                {
                    if (principal != null)
                    {
                        if (nav.RequireAllRoles)
                        {
                            if (!principal.IsInAnyRoles(nav.Roles))
                                continue;
                        }
                        else
                        {
                            if (!principal.IsInAnyRoles(nav.Roles))
                                continue;
                        }

                        result.Add(nav);
                    }
                }
                else
                {
                    result.Add(nav);
                }
            }

            return result;
        }
    }
}
