﻿using System;
using System.Web.Mvc;
using Castle.Windsor;
using ThreeBytes.Core.Extensions.Web;

namespace ThreeBytes.Core.Web.Mvc.PrecompiledViewEngine
{
    public class WindsorPrecompiledViewEngine : VirtualPathProviderViewEngine
    {
        private readonly IWindsorContainer container;

        public WindsorPrecompiledViewEngine(IWindsorContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            AreaViewLocationFormats = new string[4]
                                               {
                                                   "~/Areas/{2}/Views/{1}/{0}.cshtml",
                                                   "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                                                   "~/Areas/{2}/Views/Shared/{0}.cshtml",
                                                   "~/Areas/{2}/Views/Shared/{0}.vbhtml"
                                               };
            AreaMasterLocationFormats = new string[4]
                                                 {
                                                     "~/Areas/{2}/Views/{1}/{0}.cshtml",
                                                     "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                                                     "~/Areas/{2}/Views/Shared/{0}.cshtml",
                                                     "~/Areas/{2}/Views/Shared/{0}.vbhtml"
                                                 };
            AreaPartialViewLocationFormats = new string[4]
                                                      {
                                                          "~/Areas/{2}/Views/{1}/{0}.cshtml",
                                                          "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                                                          "~/Areas/{2}/Views/Shared/{0}.cshtml",
                                                          "~/Areas/{2}/Views/Shared/{0}.vbhtml"
                                                      };
            ViewLocationFormats = new string[4]
                                           {
                                               "~/Views/{1}/{0}.cshtml",
                                               "~/Views/{1}/{0}.vbhtml",
                                               "~/Views/Shared/{0}.cshtml",
                                               "~/Views/Shared/{0}.vbhtml"
                                           };
            MasterLocationFormats = new string[4]
                                             {
                                                 "~/Views/{1}/{0}.cshtml",
                                                 "~/Views/{1}/{0}.vbhtml",
                                                 "~/Views/Shared/{0}.cshtml",
                                                 "~/Views/Shared/{0}.vbhtml"
                                             };
            PartialViewLocationFormats = new string[4]
                                                  {
                                                      "~/Views/{1}/{0}.cshtml",
                                                      "~/Views/{1}/{0}.vbhtml",
                                                      "~/Views/Shared/{0}.cshtml",
                                                      "~/Views/Shared/{0}.vbhtml"
                                                  };
            FileExtensions = new string[1]
                                      {
                                          "cshtml"
                                      };

            this.container = container;
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            return Exists(virtualPath, IsMobile(controllerContext));
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return GetView(controllerContext, partialPath, false);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return GetView(controllerContext, viewPath, true);
        }

        // Attempt to find page from container. If you do great return it. If not and the context is mobile, try and resolve a normal webpage to fall back on.
        private PrecompiledView GetView(ControllerContext controllerContext, string path, bool runViewStart)
        {
            bool isMobile = IsMobile(controllerContext);

            WebViewPage type;

            try
            {
                type = container.Kernel.Resolve<WebViewPage>(GetKey(path, isMobile));
            }
            catch (Exception)
            {
                type = null;
            }

            return type != null ? new PrecompiledView(path, type, runViewStart, FileExtensions) : null;
        }

        public bool Exists(string virtualPath, bool isMobile)
        {
            WebViewPage page;

            try
            {
                page = container.Kernel.Resolve<WebViewPage>(GetKey(virtualPath, isMobile));
            }
            catch (Exception)
            {
                page = null;
            }

            return page != null;
        }

        private bool IsMobile(ControllerContext context)
        {
            return context.HttpContext.IsMobile();
        }

        private string GetKey(string path, bool isMobile = false)
        {
            string s = path.TrimStart("~/Views/".ToCharArray()).TrimEnd("cshtml".ToCharArray()).Replace('/', '.');
            s = s.Remove(s.Length - 1, 1);

            if (isMobile)
            {
                string[] keySplit = s.Split('.');
                int lastIndex = keySplit.Length;
                s = string.Format("{0}.{1}.{2}", keySplit[lastIndex - 2], "Mobile", keySplit[lastIndex - 1]);
            }

            return s;
        }
    }
}