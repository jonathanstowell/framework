using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;

namespace ThreeBytes.Core.IoC.Unity
{
    /// <summary>
    /// Provides controllers when requested. Automatically returns them with
    /// concrete classes injected for the interfaces.
    /// </summary>
    public class UnityControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Container of Interfaces and their matching classes.
        /// </summary>
        readonly IUnityContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityControllerFactory"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public UnityControllerFactory(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.container = container;
        }

        /// <summary>
        /// Gets the controller instance.
        /// </summary>
        /// <param name="reqContext">The req context.</param>
        /// <param name="controllerType">Type of the controller.</param>
        /// <returns></returns>
        /// <exception cref="HttpException"><c>HttpException</c>.</exception>
        /// <exception cref="ArgumentException">controllerType</exception>
        /// <exception cref="InvalidOperationException"><c>InvalidOperationException</c>.</exception>
        protected override IController GetControllerInstance(RequestContext reqContext, Type controllerType)
        {
            IController controller;
            if (controllerType == null)
                throw new HttpException(
                        404, String.Format(
                            "The controller for path '{0}' could not be found" +
            "or it does not implement IController.",
                        reqContext.HttpContext.Request.Path));

            if (!typeof(IController).IsAssignableFrom(controllerType))
                throw new ArgumentException(
                        string.Format(
                            "Type requested is not a controller: {0}",
                            controllerType.Name),
                            "controllerType");
            try
            {
                //controller = MvcUnityContainer.Container.Resolve(controllerType)
                //                as IController;
                controller = container.Resolve(controllerType) as IController;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format(
                                        "Error resolving controller {0}",
                                        controllerType.Name), ex);
            }
            return controller;
        }

    }

    /// <summary>
    /// Manages Objects for the lifetime of a web request.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpContextLifetimeManager<T> : LifetimeManager, IDisposable
    {
        /// <summary>
        /// Retrieve a value from the backing store associated with this Lifetime policy.
        /// </summary>
        /// <returns>
        /// the object desired, or null if no such object is currently stored.
        /// </returns>
        public override object GetValue()
        {
            return HttpContext.Current.Items[typeof(T).AssemblyQualifiedName];
        }

        /// <summary>
        /// Remove the given object from backing store.
        /// </summary>
        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(typeof(T).AssemblyQualifiedName);
        }

        /// <summary>
        /// Stores the given value into backing store for retrieval later.
        /// </summary>
        /// <param name="newValue">The object being stored.</param>
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[typeof(T).AssemblyQualifiedName] = newValue;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            RemoveValue();
        }
    }
}