using System;
using System.Web.Mvc;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Castle.Windsor;
using FluentValidation.Mvc;
using ThreeBytes.Core.FluentValidation;

namespace ThreeBytes.Email.WebUI.Installers
{
    public class FluentValidationStartupTask : IStartupTask
    {
        public void Run()
        {
            var validationFactory = new WindsorValidatorFactory((IWindsorContainer)Bootstrapper.Container);
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(validationFactory));
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}