using System;
using System.Web;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Security.Utilities.Abstract;

namespace ThreeBytes.Core.Security.Utilities.Concrete
{
    public class ProvideCurrentUserDetails : IProvideCurrentUserDetails
    {
        public string Username
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }

        public Guid UserId
        {
            get { return ((ThreeBytesPrincipal)HttpContext.Current.User).UserId; }
        }

        public bool IsFromExternalProvider
        {
            get { return !string.IsNullOrEmpty(ExternalProvider); }
        }

        public string ExternalProvider
        {
            get { return ((ThreeBytesPrincipal)HttpContext.Current.User).ExternalProvider; }
        }
    }
}
