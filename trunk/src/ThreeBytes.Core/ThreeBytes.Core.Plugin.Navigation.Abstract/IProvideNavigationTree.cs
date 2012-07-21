using ThreeBytes.Core.DataStructures;
using ThreeBytes.Core.Security.Concrete;

namespace ThreeBytes.Core.Plugin.Navigation.Abstract
{
    public interface IProvideNavigationTree
    {
        DataStructures.Navigation GetNavigation(ThreeBytesPrincipal principal);
    }
}
