using SignalR.Hubs;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;
using ThreeBytes.SignalR.Hubs;

namespace ThreeBytes.ProjectHollywood.Team.Management.Frontend.Hubs
{
    [HubName("teamManagementDeletionHub")]
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "TeamManager" })]
    public class TeamManagementDeletionHub : GenericHub<TeamManagementEmployee>
    {
        public TeamManagementDeletionHub(ICurrentlyViewingUserService service)
            : base(service)
        {
        }
    }
}