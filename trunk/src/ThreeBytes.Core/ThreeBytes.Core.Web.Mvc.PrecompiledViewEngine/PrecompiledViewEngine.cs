using System.Collections.Generic;
using System.Web.Mvc;
using ThreeBytes.Core.Extensions.Web;

namespace ThreeBytes.Core.Web.Mvc.PrecompiledViewEngine
{
    public class PrecompiledViewEngine : VirtualPathProviderViewEngine
    {
        private readonly IDictionary<string, WebViewPage> mappings;

        public PrecompiledViewEngine(WebViewPage[] pages)
        {
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

            mappings = new Dictionary<string, WebViewPage>();

            foreach (var view in pages)
            {
                if (view.GetType().FullName.Contains("Mobile"))
                {
                    string[] keySplit = view.GetType().FullName.Split('.');
                    int lastIndex = keySplit.Length;
                    mappings.Add(string.Format("{0}.{1}.{2}", keySplit[lastIndex - 3], keySplit[lastIndex - 2], keySplit[lastIndex - 1]), view);
                }
                else
                {
                    string[] keySplit = view.GetType().FullName.Split('.');
                    int lastIndex = keySplit.Length;
                    mappings.Add(string.Format("{0}.{1}", keySplit[lastIndex - 2], keySplit[lastIndex - 1]), view);
                }
            }
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            return Exists(virtualPath, IsMobile(controllerContext));
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            bool isMobile = IsMobile(controllerContext);
            string key = GetKey(partialPath, isMobile);
            WebViewPage type;
            if (mappings.TryGetValue(key, out type))
            {
                return new PrecompiledView(partialPath, type, false, FileExtensions);
            }

            return null;
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            bool isMobile = IsMobile(controllerContext);
            string key = GetKey(viewPath, isMobile);
            WebViewPage type;
            if (mappings.TryGetValue(key, out type))
            {
                return new PrecompiledView(viewPath, type, true, FileExtensions);
            }

            return null;
        }

        public bool Exists(string virtualPath, bool isMobile)
        {
            return mappings.ContainsKey(GetKey(virtualPath, isMobile));
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
