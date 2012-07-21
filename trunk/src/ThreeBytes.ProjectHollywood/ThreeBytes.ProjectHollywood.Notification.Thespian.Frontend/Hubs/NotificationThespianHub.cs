using SignalR.Hubs;
using ThreeBytes.Core.Security.Concrete;

namespace ThreeBytes.ProjectHollywood.Notification.Thespian.Frontend.Hubs
{
    [HubName("notificationThespianHub")]
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "ThespianManager" })]
    public class NotificationThespianHub : Hub
    {
    }
}
