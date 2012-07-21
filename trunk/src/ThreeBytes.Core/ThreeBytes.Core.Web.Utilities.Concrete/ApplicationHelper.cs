using System;
using System.Web;
using ThreeBytes.Core.Web.Utilities.Abstract;

namespace ThreeBytes.Core.Web.Utilities.Concrete
{
    public class ApplicationHelper : IApplicationHelper
    {
        public Uri ApplicationRoot
        {
            get
            {
                string appRoot = HttpContext.Current.Request.ApplicationPath;
                if (!appRoot.EndsWith("/", StringComparison.Ordinal))
                {
                    appRoot += "/";
                }

                return new Uri(HttpContext.Current.Request.Url, appRoot);
            }
        }
    }
}
