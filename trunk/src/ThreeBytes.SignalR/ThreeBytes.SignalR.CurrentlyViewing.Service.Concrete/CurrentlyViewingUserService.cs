using System;
using System.Collections.Generic;
using System.Linq;
using ThreeBytes.Core.Caching.Abstract;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Configuration.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Entities.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Entities.Concrete;
using ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract;

namespace ThreeBytes.SignalR.CurrentlyViewing.Service.Concrete
{
    public class CurrentlyViewingUserService : ICurrentlyViewingUserService
    {
        private readonly ICacheManager cacheManager;
        private readonly IProvideCurrentlyViewingConfiguration configuration;

        public CurrentlyViewingUserService(ICacheManager cacheManager, IProvideCurrentlyViewingConfiguration configuration)
        {
            this.cacheManager = cacheManager;
            this.configuration = configuration;
        }

        public IList<ICurrentlyViewingUser> GetCurrentlyViewingUsers<T>(Guid id) where T : class, IBusinessObject<T>
        {
            var users = cacheManager.GetCurrentlyViewingUsers<ICurrentlyViewingUser>(id, typeof(T));
            return users ?? new List<ICurrentlyViewingUser>();
        }

        public void AddCurrentlyViewingUser<T>(string id, string username, out string colour) where T : class, IBusinessObject<T>
        {
            IList<ICurrentlyViewingUser> users = cacheManager.GetCurrentlyViewingUsers<ICurrentlyViewingUser>(id, typeof(T));

            colour = GetUserAColour(users);

            ICurrentlyViewingUser user = new CurrentlyViewingUser { Username = username, Colour = colour };

            if (users == null)
            {
                users = new List<ICurrentlyViewingUser> { user };
                cacheManager.AddCurrentlyViewingUsers(id, typeof(T), users);
            }
            else
            {
                if (users.SingleOrDefault(x => x.Username == username) != null)
                    return;

                users.Add(user);
                cacheManager.ReplaceCurrentlyViewingUsers(id, typeof(T), users);
            }
        }

        public void RemoveCurrentlyViewingUser<T>(string id, string username) where T : class, IBusinessObject<T>
        {
            IList<ICurrentlyViewingUser> users = cacheManager.GetCurrentlyViewingUsers<ICurrentlyViewingUser>(id, typeof(T));

            if (users == null)
                return;

            ICurrentlyViewingUser user = users.SingleOrDefault(x => x.Username == username);

            if (user == null)
                return;

            users.Remove(user);
            cacheManager.ReplaceCurrentlyViewingUsers(id, typeof(T), users);
        }

        public string GetCurrentlyViewingUserColour<T>(string id, string username) where T : class, IBusinessObject<T>
        {
            IList<ICurrentlyViewingUser> users = cacheManager.GetCurrentlyViewingUsers<ICurrentlyViewingUser>(id, typeof(T));

            if (users == null)
                return null;

            ICurrentlyViewingUser user = users.SingleOrDefault(x => x.Username == username);

            return user == null ? null : user.Colour;
        }

        private string GetUserAColour(IList<ICurrentlyViewingUser> users)
        {
            Random rnd = new Random(configuration.CurrentlyViewingCssColourClasses.Count());
            return users == null ? configuration.CurrentlyViewingCssColourClasses.OrderBy(x => rnd.Next()).FirstOrDefault() : configuration.CurrentlyViewingCssColourClasses.Except(users.Select(y => y.Colour).ToArray()).FirstOrDefault();
        }
    }
}
