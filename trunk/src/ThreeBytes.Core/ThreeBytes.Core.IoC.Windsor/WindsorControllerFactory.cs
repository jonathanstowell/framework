using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace ThreeBytes.Core.IoC.Windsor
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.container = container;
        }

        public override void ReleaseController(IController controller)
        {
            container.Kernel.ReleaseComponent(controller);
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                return container.Kernel.Resolve<IController>(controllerName + "Controller") as Controller;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
