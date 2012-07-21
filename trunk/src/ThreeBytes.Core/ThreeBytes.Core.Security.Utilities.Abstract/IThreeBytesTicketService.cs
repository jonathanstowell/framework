using System;
using System.Web;
using ThreeBytes.Core.Security.Concrete;

namespace ThreeBytes.Core.Security.Utilities.Abstract
{
    public interface IThreeBytesTicketService
    {
        HttpCookie GetHttpCookie(Guid id, string username, string roles, string extAuth = "");
        ThreeBytesPrincipal GetPrinciple(HttpCookie cookie);
    }
}
