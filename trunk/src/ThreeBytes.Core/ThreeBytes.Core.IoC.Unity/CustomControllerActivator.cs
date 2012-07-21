using System;
using System.Web.Mvc;

namespace ThreeBytes.Core.IoC.Unity
{
    /// <summary>
    /// Overrides the way MVC creates controllers in order to provide dependency
    /// injection of classes.
    /// </summary>
    public class CustomControllerActivator : IControllerActivator
    {
        #region IControllerActivator Members
        /// <summary>
        /// When implemented in a class, creates a controller.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        /// <param name="controllerType">The controller type.</param>
        /// <returns>
        /// The created controller.
        /// </returns>
        public IController Create(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
        #endregion
    }
}
