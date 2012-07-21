using System.Web;

namespace ThreeBytes.Core.Extensions.Web
{
    public static class Mobile
    {
        public static bool IsMobile(this HttpContextBase httpRequest)
        {
            return httpRequest.Request.IsMobile();
        }

        public static bool IsMobile(this HttpRequestBase httpRequest)
        {
            string userAgent = httpRequest.UserAgent.ToLower();
            
            return userAgent.Contains("iphone") |
                 userAgent.Contains("ppc") |
                 userAgent.Contains("windows ce") |
                 userAgent.Contains("blackberry") |
                 userAgent.Contains("opera mini") |
                 userAgent.Contains("mobile") |
                 userAgent.Contains("palm") |
                 userAgent.Contains("portable") |
                 userAgent.Contains("opera mobi") |
                 httpRequest.Browser.IsMobileDevice;
        }
    }
}
