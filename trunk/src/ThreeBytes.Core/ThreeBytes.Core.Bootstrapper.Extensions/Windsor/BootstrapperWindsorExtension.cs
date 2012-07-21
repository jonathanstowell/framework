using Bootstrap.Extensions;
using Bootstrap.Extensions.Containers;
using ThreeBytes.Core.Plugin.Abstract;

namespace ThreeBytes.Core.Bootstrapper.Extensions.Windsor
{
    public static class BootstrapperWindsorExtension
    {
        public static IBootstrapperContainerExtensionOptions Windsor(this BootstrapperExtensions extensions)
        {
            var extension = new WindsorExtension();
            extensions.Extension(extension);
            return extension.Options;
        }

        public static IBootstrapperContainerExtensionOptions Windsor(this BootstrapperExtensions extensions, IResolveAssemblies resolveAssemblies, BootstrapEnvironment bootstrapEnvironment)
        {
            var extension = new WindsorExtension(resolveAssemblies, bootstrapEnvironment);
            extensions.Extension(extension);
            return extension.Options;
        }
    }
}
