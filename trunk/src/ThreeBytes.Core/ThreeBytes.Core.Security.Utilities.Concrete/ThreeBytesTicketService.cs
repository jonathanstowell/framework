using System;
using System.Web;
using System.Web.Security;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Security.Utilities.Abstract;

namespace ThreeBytes.Core.Security.Utilities.Concrete
{
    public class ThreeBytesTicketService : IThreeBytesTicketService
    {
        public HttpCookie GetHttpCookie(Guid id, string username, string roles, string extAuth = "")
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        username,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(60),
                        false,
                        string.Format("{0},{1},{2}", id, roles, extAuth));

            string encTicket = FormsAuthentication.Encrypt(ticket);

            return new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
        }

        public ThreeBytesPrincipal GetPrinciple(HttpCookie cookie)
        {
            if (cookie == null)
                return null;

            if (string.IsNullOrEmpty(cookie.Value))
                return null;

            try
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(cookie.Value);
                string[] userData = authTicket.UserData.Split(',');
                Guid userId = Guid.Parse(userData[0]);
                string[] roles = userData[1].Split('|');
                string externalProvider = userData[2];
                FormsIdentity id = new FormsIdentity(authTicket);
                return new ThreeBytesPrincipal(id, userId, roles, externalProvider);
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
