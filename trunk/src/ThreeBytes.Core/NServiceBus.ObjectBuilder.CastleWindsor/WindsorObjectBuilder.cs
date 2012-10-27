using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NServiceBus.ObjectBuilder;
using NServiceBus.ObjectBuilder.Common;

namespace NServiceBus.ObjectBuilder.CastleWindsor
{
    public class WindsorObjectBuilder : IContainer
    {
        [ThreadStatic]
        private static IList<object> resolvedInstancesToRelease;

        public IWindsorContainer Container { get; set; }

        static IList<object> ResolvedInstancesToRelease
        {
            get
            {
                if (WindsorObjectBuilder.resolvedInstancesToRelease == null)
                    WindsorObjectBuilder.resolvedInstancesToRelease = (IList<object>)new List<object>();
                return WindsorObjectBuilder.resolvedInstancesToRelease;
            }
        }

        public WindsorObjectBuilder()
            : this((IWindsorContainer)new WindsorContainer())
        {
        }

        public WindsorObjectBuilder(IWindsorContainer container)
        {
            this.Container = container;
            InstanceReleasingMessageModule.Builder = this;
        }

        void IContainer.Configure(Type concreteComponent, ComponentCallModelEnum callModel)
        {
            if (this.GetHandlerForType(concreteComponent) != null)
                return;
            LifestyleType lifestyleTypeFrom = WindsorObjectBuilder.GetLifestyleTypeFrom(callModel);
            ComponentRegistration<object> componentRegistration = Component.For(WindsorObjectBuilder.GetAllServiceTypesFor(concreteComponent)).ImplementedBy(concreteComponent);
            componentRegistration.LifeStyle.Is(lifestyleTypeFrom);
            this.Container.Kernel.Register(new IRegistration[1]
      {
        (IRegistration) componentRegistration
      });
        }

        void IContainer.ConfigureProperty(Type component, string property, object value)
        {
            IHandler handlerForType = this.GetHandlerForType(component);
            if (handlerForType == null)
                throw new InvalidOperationException("Cannot configure property for a type which hadn't been configured yet. Please call 'Configure' first.");
            handlerForType.AddCustomDependencyValue(property, value);
        }

        void IContainer.RegisterSingleton(Type lookupType, object instance)
        {
            this.Container.Kernel.AddComponentInstance(Guid.NewGuid().ToString(), lookupType, instance);
        }

        object IContainer.Build(Type typeToBuild)
        {
            object obj = (object)null;
            if (this.Container.Kernel.HasComponent(typeToBuild))
            {
                obj = this.Container.Resolve(typeToBuild);
                IHandler handler = this.Container.Kernel.GetHandler(typeToBuild);
                if (handler != null && handler.ComponentModel.LifestyleType == LifestyleType.Transient)
                    WindsorObjectBuilder.ResolvedInstancesToRelease.Add(obj);
            }
            return obj;
        }

        IEnumerable<object> IContainer.BuildAll(Type typeToBuild)
        {
            foreach (object obj in this.Container.ResolveAll(typeToBuild))
                yield return obj;
        }

        private static LifestyleType GetLifestyleTypeFrom(ComponentCallModelEnum callModel)
        {
            switch (callModel - 1)
            {
                case ComponentCallModelEnum.Singleton:
                    return LifestyleType.Singleton;
                case ComponentCallModelEnum.Singlecall:
                    return LifestyleType.Transient;
                default:
                    return LifestyleType.Singleton;
            }
        }

        private static IEnumerable<Type> GetAllServiceTypesFor(Type t)
        {
            if (t == (Type)null)
                return (IEnumerable<Type>)new List<Type>();
            List<Type> list = new List<Type>((IEnumerable<Type>)t.GetInterfaces())
      {
        t
      };
            foreach (Type t1 in t.GetInterfaces())
                list.AddRange(WindsorObjectBuilder.GetAllServiceTypesFor(t1));
            return (IEnumerable<Type>)list;
        }

        private IHandler GetHandlerForType(Type concreteComponent)
        {
            return Enumerable.FirstOrDefault<IHandler>(Enumerable.Where<IHandler>((IEnumerable<IHandler>)this.Container.Kernel.GetAssignableHandlers(typeof(object)), (Func<IHandler, bool>)(h => h.ComponentModel.Implementation == concreteComponent)));
        }

        public void ReleaseResolvedInstances()
        {
            foreach (object instance in (IEnumerable<object>)WindsorObjectBuilder.ResolvedInstancesToRelease)
                this.Container.Release(instance);
            WindsorObjectBuilder.ResolvedInstancesToRelease.Clear();
        }
    }
}
