using Bootstrap.Extensions;
using Bootstrap.Extensions.Containers;
using Castle.Core.Internal;
using Castle.MicroKernel;
using ThreeBytes.Core.Plugin.Abstract;

namespace ThreeBytes.Core.Bootstrapper.Extensions.Windsor
{
    public static class ThreeBytesBootstrapperWindsorHelper
    {
        public static IBootstrapperContainerExtensionOptions Windsor(this BootstrapperExtensions extensions, IResolveAssemblies assemblyResolver, BootstrapEnvironment bootstrapEnvironment, params IFacility[] facilities)
        {
            var windsorExtension = new ThreeBytesWindsorExtension(assemblyResolver, bootstrapEnvironment, new RegistrationHelper());
            facilities.ForEach(windsorExtension.AddFacility);
            extensions.Extension(windsorExtension);
            return windsorExtension.Options;
        }
    }
}
