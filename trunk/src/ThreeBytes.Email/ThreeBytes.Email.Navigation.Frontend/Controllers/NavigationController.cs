using System;
using System.Web.Mvc;
using ThreeBytes.Core.Plugin.Navigation.Abstract;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Web.Mvc.Controllers;
using ThreeBytes.Email.Navigation.Frontend.Models;

namespace ThreeBytes.Email.Navigation.Frontend.Controllers
{
    public class NavigationController : StatelessSessionController
    {
        private readonly IProvideNavigationTree provideNavigation;

        public NavigationController(IProvideNavigationTree provideNavigation)
        {
            if (provideNavigation == null)
                throw new ArgumentNullException("provideNavigation");

            this.provideNavigation = provideNavigation;
        }

        public ActionResult Index()
        {
            ThreeBytesPrincipal principal;

            try
            {
                principal = (ThreeBytesPrincipal) User;
            }
            catch
            {
                principal = null;
            }

            return PartialView(new NavigationViewModel { Navigation = provideNavigation.GetNavigation(principal) });
        }
    }
}
