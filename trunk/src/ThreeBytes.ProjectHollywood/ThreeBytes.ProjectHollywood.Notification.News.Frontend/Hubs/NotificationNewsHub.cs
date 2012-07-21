using SignalR.Hubs;
using ThreeBytes.Core.Security.Concrete;

namespace ThreeBytes.ProjectHollywood.Notification.News.Frontend.Hubs
{
    [HubName("notificationNewsHub")]
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "NewsManager" })]
    public class NotificationNewsHub : Hub
    {
    }
}
