using SignalR.Hubs;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.ProjectHollywood.Team.Management.Entities;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;
using ThreeBytes.SignalR.Hubs;

namespace ThreeBytes.ProjectHollywood.Team.Management.Frontend.Hubs
{
    [HubName("teamManagementHub")]
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "TeamManager" })]
    public class TeamManagementHub : GenericHub<TeamManagementEmployee>
    {
        public TeamManagementHub(ICurrentlyViewingUserService service) : base(service)
        {
        }
    }
}
