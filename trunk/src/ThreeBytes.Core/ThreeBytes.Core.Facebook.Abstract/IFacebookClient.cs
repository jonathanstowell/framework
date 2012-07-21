using System.Collections.Generic;
using ThreeBytes.Core.Facebook.Entities.Abstract;

namespace ThreeBytes.Core.Facebook.Abstract
{
    public interface IFacebookClient
    {
        string GetLoginUrl(string redirect);
        string GetLoginUrl(string redirect, IDictionary<string, object> parameters);
        IFacebookUserProfile GetUserFromCode(string code);
        bool HasLoginBeenSuccessful(string url);
    }
}
