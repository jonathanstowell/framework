using System;
using Castle.Windsor;
using FluentValidation;

namespace ThreeBytes.Core.FluentValidation
{
    public class WindsorValidatorFactory : ValidatorFactoryBase
    {
        private readonly IWindsorContainer container;

        public WindsorValidatorFactory(IWindsorContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return container.Kernel.HasComponent(validatorType)
                         ? container.Resolve(validatorType) as IValidator
                         : null;
        }
    }
}
