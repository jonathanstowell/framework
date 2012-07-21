using System;
using System.Web;
using System.Web.Mvc;

namespace ThreeBytes.Core.Security.Concrete
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class ThreeBytesAuthorisation : AuthorizeAttribute
    {
        private string[] authorizedRoles;
        public string[] AuthorizedRoles
        {
            get { return authorizedRoles ?? new string[0]; }
            set { authorizedRoles = value; }
        }

        public bool AnyRole { get; set; }

        private bool isAuthenticationError;
        private bool isRoleError;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext); 
         
            //If its an unauthorized/timed out ajax request go to top window and redirect to logon.
            //if (filterContext.Result is HttpUnauthorizedResult && filterContext.HttpContext.Request.IsAjaxRequest())
            //            filterContext.Result = new JavaScriptResult() { Script = top.location = '/Account/LogOn?Expired=1'; };
 
            //If authorization results in HttpUnauthorizedResult, redirect to error page instead of Logon page.
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                if (isAuthenticationError)
                {
                    filterContext.Result = string.Equals(filterContext.ActionDescriptor.ActionName, "Index") ? new RedirectResult(string.Format("~/Login/RedirectUrl/{0}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName)) : new RedirectResult(string.Format("~/Login/RedirectUrl/{0}/{1}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName));
                }

                if (isRoleError)
                {
                    filterContext.Result = new RedirectResult("~/Error/Roles");
                }
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            ThreeBytesPrincipal user = HttpContext.Current.User as ThreeBytesPrincipal;

            if (user == null)
            {
                isAuthenticationError = true;
                return false;
            }

            if (!user.Identity.IsAuthenticated)
            {
                isAuthenticationError = true;
                return false;
            }

            if (user.IsInRole("Admin"))
                return true;
 
            if(AuthorizedRoles.Length == 0)
                return true;

            if (AnyRole)
            {
                if (user.IsInAnyRoles(AuthorizedRoles))
                    return true;
            }
            else
            {
                if (user.IsInAllRoles(AuthorizedRoles))
                    return true;
            }

            isRoleError = true;

            return false;
        }
    }
}
