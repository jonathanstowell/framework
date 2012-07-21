using System;
using System.Web.Mvc;

namespace ThreeBytes.Core.Web.Mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        protected Uri GetAbsoluteUrl(string action, string controller)
        {
            return new UriBuilder(string.Format("http://{0}", Request.Url.Authority))
            {
                Path = Url.Action(action, controller)
            }.Uri;
        }

        protected string GetAbsoluteUrlAsString(string action, string controller)
        {
            return new UriBuilder(string.Format("http://{0}", Request.Url.Authority))
            {
                Path = Url.Action(action, controller)
            }.Uri.ToString();
        }
    }
}
