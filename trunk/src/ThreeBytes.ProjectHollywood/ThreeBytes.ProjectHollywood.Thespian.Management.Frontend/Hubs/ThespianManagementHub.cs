using SignalR.Hubs;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;
using ThreeBytes.SignalR.Hubs;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.Hubs
{
    [HubName("thespianManagementHub")]
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "ThespianManager" })]
    public class ThespianManagementHub : GenericHub<ThespianManagementThespian>
    {
        public ThespianManagementHub(ICurrentlyViewingUserService service) : base(service)
        {
        }
    }
}
