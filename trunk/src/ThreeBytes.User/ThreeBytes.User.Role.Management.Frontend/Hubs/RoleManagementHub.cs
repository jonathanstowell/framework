using SignalR.Hubs;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;
using ThreeBytes.SignalR.Hubs;
using ThreeBytes.User.Role.Management.Entities;

namespace ThreeBytes.User.Role.Management.Frontend.Hubs
{
    [HubName("roleManagementHub")]
    public class RoleManagementHub : GenericHub<RoleManagementRole>
    {
        public RoleManagementHub(ICurrentlyViewingUserService service) : base(service)
        {
        }
    }
}
