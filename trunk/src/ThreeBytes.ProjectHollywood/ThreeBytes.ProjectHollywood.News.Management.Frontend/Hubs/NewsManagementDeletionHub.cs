using SignalR.Hubs;
using ThreeBytes.Core.Security.Concrete;

namespace ThreeBytes.ProjectHollywood.News.Management.Frontend.Hubs
{
    [HubName("newsManagementDeletionHub")]
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "NewsManager" })]
    public class NewsManagementDeletionHub : Hub
    {
    }
}