using SignalR.Hubs;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;
using ThreeBytes.SignalR.Hubs;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Frontend.Hubs
{
    [HubName("userManagementHub")]
    public class UserManagementHub : GenericHub<AuthenticationUserManagementUser>
    {
        public UserManagementHub(ICurrentlyViewingUserService service) : base(service)
        {
        }

        public void AddedRole(string userId, string roleId)
        {
            Clients.handleAddedRole(userId, roleId);
        }

        public void RemovedRole(string userId, string roleId)
        {
            Clients.handleRemovedRole(userId, roleId);
        }
    }
}
