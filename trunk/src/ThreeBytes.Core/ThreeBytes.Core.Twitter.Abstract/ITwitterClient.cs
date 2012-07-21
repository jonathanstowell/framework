using System.Collections.Generic;
using ThreeBytes.Core.Twitter.Entities.Abstract;

namespace ThreeBytes.Core.Twitter.Abstract
{
    public interface ITwitterClient
    {
        string GetLoginUrl(string redirect);
        string GetLoginUrl(string redirect, IDictionary<string, object> parameters);
        ITwitterUserProfile GetUser(string oauthToken, string oauthVerifier);
        bool HasLoginBeenSuccessful(string url);
    }
}
