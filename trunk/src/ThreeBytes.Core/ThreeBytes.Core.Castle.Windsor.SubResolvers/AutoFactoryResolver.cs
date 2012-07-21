using System;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;

namespace ThreeBytes.Core.Castle.Windsor.SubResolvers
{
    // http://mikehadlow.blogspot.com/2010/01/10-advanced-windsor-tricks-1a-delegate.html
    public class AutoFactoryResolver : ISubDependencyResolver
    {
        private readonly IKernel kernel;

        public AutoFactoryResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object Resolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            var getResolveDelegateGeneric = GetType().GetMethod("GetResolveDelegate");
            var getResolveDelegateMethod =
                getResolveDelegateGeneric.MakeGenericMethod(dependency.TargetType.GetGenericArguments()[0]);
            return getResolveDelegateMethod.Invoke(this, null);
        }

        public bool CanResolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            return dependency.TargetType.IsGenericType
                && (dependency.TargetType.GetGenericTypeDefinition() == typeof(Func<>))
                && (kernel.HasComponent(dependency.TargetType.GetGenericArguments()[0]));
        }

        public Func<T> GetResolveDelegate<T>()
        {
            return () => kernel.Resolve<T>();
        }
    }
}
