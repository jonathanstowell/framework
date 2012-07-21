using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.WebPages;

namespace ThreeBytes.Core.Web.Mvc.PrecompiledViewEngine
{
    internal delegate WebPageRenderingBase StartPageLookupDelegate(WebPageRenderingBase page, string fileName, IEnumerable<string> supportedExtensions);

    public interface IPrecompiledView
    {

    }

    public class PrecompiledView : IView
    {
        private readonly WebViewPage type;
        private readonly string virtualPath;

        public bool RunViewStartPages { get; private set; }

        public IEnumerable<string> ViewStartFileExtensions { get; private set; }

        public PrecompiledView(string virtualPath, WebViewPage type, bool runViewStartPages, IEnumerable<string> fileExtension)
        {
            this.type = type;
            this.virtualPath = virtualPath;
            RunViewStartPages = runViewStartPages;
            ViewStartFileExtensions = fileExtension;
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            WebViewPage webViewPage = type;
            if (webViewPage == null)
                throw new InvalidOperationException("Invalid view type");
            webViewPage.VirtualPath = virtualPath;
            webViewPage.ViewContext = viewContext;
            webViewPage.ViewData = viewContext.ViewData;
            webViewPage.InitHelpers();
            WebPageRenderingBase startPage = (WebPageRenderingBase)null;
            if (RunViewStartPages)
            {
                startPage = StartPage.GetStartPage(webViewPage, "_ViewStart", ViewStartFileExtensions);
            }
            WebPageContext pageContext = new WebPageContext(viewContext.HttpContext, webViewPage, null);
            webViewPage.ExecutePageHierarchy(pageContext, writer, startPage);
        }
    }
}
