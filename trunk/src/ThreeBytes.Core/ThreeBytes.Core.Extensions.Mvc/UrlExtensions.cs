using System;
using System.Web;
using System.Web.Mvc;

namespace ThreeBytes.Core.Extensions.Mvc
{
    public static class Extensions
    {
        public static Uri ActionFull(this UrlHelper urlHelper, string actionName)
        {
            return new Uri(HttpContext.Current.Request.Url, urlHelper.Action(actionName));
        }

        public static Uri ActionFull(this UrlHelper urlHelper, string actionName, string controllerName)
        {
            return new Uri(HttpContext.Current.Request.Url, urlHelper.Action(actionName, controllerName));
        }
    }
}
