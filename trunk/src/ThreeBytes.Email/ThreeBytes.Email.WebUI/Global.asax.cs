using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Castle.Windsor;
using MvcMiniProfiler;
using NServiceBus;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor;
using ThreeBytes.Core.Plugin.Abstract;
using ThreeBytes.Core.Plugin.Concrete;
using ThreeBytes.Core.Security.Concrete;
using ThreeBytes.Core.Security.Utilities.Abstract;
using ThreeBytes.Email.WebUI.Installers;

namespace ThreeBytes.Email.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static IWindsorContainer Container;
        public static IResolveAssemblies AssemblyResolver = new ResolveAssemblies("Plugins", "ThreeBytes.*.dll");
        public static IBus Bus { get; set; }

        protected IThreeBytesTicketService TicketService
        {
            get { return Container.Resolve<IThreeBytesTicketService>(); }
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "EmailDashboardHost", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            Bootstrapper.With.Windsor(AssemblyResolver, BootstrapEnvironment.WEB).And.StartupTasks()
                .UsingThisExecutionOrder(s => s
                        .First<AppDomainAssemblyResolverStartupTask>()
                        .Then<WindsorSetupStartupTask>()
                        .Then<NServiceBusStartupTask>()
                        .Then().TheRest())
                .Start();

            Container = (IWindsorContainer)Bootstrapper.Container;

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                Context.User = TicketService.GetPrinciple(authCookie);
            }
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}