using SignalR.Hubs;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.ProjectHollywood.Thespian.Management.Entities;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;
using ThreeBytes.SignalR.Hubs;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Frontend.Hubs
{
    [HubName("thespianManagementDeletionHub")]
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "TeamManager" })]
    public class ThespianManagementDeletionHub : GenericHub<ThespianManagementThespian>
    {
        public ThespianManagementDeletionHub(ICurrentlyViewingUserService service)
            : base(service)
        {
        }
    }
}