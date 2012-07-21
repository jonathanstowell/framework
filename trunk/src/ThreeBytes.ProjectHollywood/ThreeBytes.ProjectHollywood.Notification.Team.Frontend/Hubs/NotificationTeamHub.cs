using SignalR.Hubs;
using ThreeBytes.Core.Security.Concrete;

namespace ThreeBytes.ProjectHollywood.Notification.Team.Frontend.Hubs
{
    [HubName("notificationTeamHub")]
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "TeamManager" })]
    public class NotificationTeamHub : Hub
    {
    }
}
