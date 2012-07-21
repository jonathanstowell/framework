using System.Web;
using SignalR.Hubs;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;

namespace ThreeBytes.SignalR.Hubs
{
    public class GenericHub<TEntity> : Hub where TEntity : class, IBusinessObject<TEntity>
    {
        private readonly ICurrentlyViewingUserService service;

        public GenericHub(ICurrentlyViewingUserService service)
        {
            this.service = service;
        }

        public void ImViewing(string id)
        {
            string colour;
            service.AddCurrentlyViewingUser<TEntity>(id, HttpContext.Current.User.Identity.Name, out colour);
            Clients.handleImViewingMessage(HttpContext.Current.User.Identity.Name, colour, id);
        }

        public void ImLeaving(string id)
        {
            service.RemoveCurrentlyViewingUser<TEntity>(id, HttpContext.Current.User.Identity.Name);
            Clients.handleImLeavingMessage(HttpContext.Current.User.Identity.Name, id);
        }

        public void IHaveEdited(string id, string property, string content)
        {
            string colour = service.GetCurrentlyViewingUserColour<TEntity>(id, HttpContext.Current.User.Identity.Name);

            if (string.IsNullOrEmpty(colour))
                return;

            Clients.handleIHaveEdited(id, property, content);
        }
    }
}
