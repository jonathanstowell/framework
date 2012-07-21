using System.Collections.Generic;
using ThreeBytes.Core.Foursquare.Entities.Abstract;

namespace ThreeBytes.Core.Foursquare.Abstract
{
    public interface IFoursquareClient
    {
        string GetLoginUrl(string redirect);
        string GetLoginUrl(string redirect, IDictionary<string, object> parameters);
        IFoursquareUserProfile GetUserFromCode(string code, string redirect);
    }
}
