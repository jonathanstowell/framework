using System.Collections.Generic;
using System.Reflection;

namespace ThreeBytes.Core.Plugin.Abstract
{
    public interface IResolveAssemblies
    {
        Dictionary<string, Assembly> PluginAssembliesByFullName { get; }
        Assembly GetAssembly(string name);
    }
}
