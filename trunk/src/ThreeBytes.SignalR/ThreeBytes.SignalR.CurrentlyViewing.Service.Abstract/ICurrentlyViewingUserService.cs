using System;
using System.Collections.Generic;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.SignalR.CurrentlyViewing.Entities.Abstract;

namespace ThreeBytes.SignalR.CurrentlyViewing.Service.Abstract
{
    public interface ICurrentlyViewingUserService
    {
        IList<ICurrentlyViewingUser> GetCurrentlyViewingUsers<T>(Guid id) where T : class, IBusinessObject<T>;
        void AddCurrentlyViewingUser<T>(string id, string username, out string colour) where T : class, IBusinessObject<T>;
        void RemoveCurrentlyViewingUser<T>(string id, string username) where T : class, IBusinessObject<T>;
        string GetCurrentlyViewingUserColour<T>(string id, string username) where T : class, IBusinessObject<T>;
    }
}
