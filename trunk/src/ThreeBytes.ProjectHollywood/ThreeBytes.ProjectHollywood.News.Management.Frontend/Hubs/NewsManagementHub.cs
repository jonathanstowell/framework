using SignalR.Hubs;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.ProjectHollywood.News.Management.Entities;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;
using ThreeBytes.SignalR.Hubs;

namespace ThreeBytes.ProjectHollywood.News.Management.Frontend.Hubs
{
    [HubName("newsManagementHub")]
    [ThreeBytesAuthorisation(AnyRole = true, AuthorizedRoles = new[] { "Creator", "Admin", "NewsManager" })]
    public class NewsManagementHub : GenericHub<NewsManagementNewsArticle>
    {
        public NewsManagementHub(ICurrentlyViewingUserService service) : base(service)
        {}
    }
}
