using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace ThreeBytes.Core.Extensions.SharpSquare
{
    public static class SharpSquareUserExtensions
    {
        public static object GetUserUsingToken(this Igloo.SharpSquare.Core.SharpSquare ext, string token)
        {
            ext.SetAccessToken(token);

            //https://api.foursquare.com/v2/users/self?oauth_token=FKJFKJFKJFK5SOB4&v=20120410
            string version = "20120410";
            string Url = string.Format("https://api.foursquare.com/v2/users/self?oauth_token={0}&v={1}", token, version);

            //make request.
            var first_request = (HttpWebRequest)WebRequest.Create(Url);
            var wr = first_request.GetResponse();
            //read stream
            dynamic result = SimpleJson.SimpleJson.DeserializeObject(new StreamReader(wr.GetResponseStream()).ReadToEnd());
            return result.response.user;
        }
    }
}
