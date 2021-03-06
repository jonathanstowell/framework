﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThreeBytes.ProjectHollywood.News.Host.Frontend.Views.NewsHost
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using ThreeBytes.Core.Extensions.Mvc;
    using ThreeBytes.Core.Security.Concrete;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/NewsHost/Index.cshtml")]
    public class Index : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Index()
        {
        }
        public override void Execute()
        {

            
            #line 1 "..\..\Views\NewsHost\Index.cshtml"
  
    ViewBag.Title = "News";


            
            #line default
            #line hidden
WriteLiteral("\r\n<section id=\"news-home\">\r\n    <div class=\"row\">\r\n        <div class=\"span8 colu" +
"mns\">\r\n            \r\n");


            
            #line 9 "..\..\Views\NewsHost\Index.cshtml"
             if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "NewsManager" }))
            {
                Html.RenderAction("Create", "NewsManagement");
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 14 "..\..\Views\NewsHost\Index.cshtml"
               Html.RenderAction("List", "NewsList"); 

            
            #line default
            #line hidden
WriteLiteral("       \r\n        </div>\r\n\r\n");


            
            #line 18 "..\..\Views\NewsHost\Index.cshtml"
         if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "NewsManager" }))
        {
            Html.RenderAction("Edit", "NewsManagement");
            Html.RenderAction("Delete", "NewsManagement");
        }

            
            #line default
            #line hidden
WriteLiteral("        \r\n");


            
            #line 24 "..\..\Views\NewsHost\Index.cshtml"
           Html.RenderAction("Details", "NewsView");

            
            #line default
            #line hidden
WriteLiteral("                \r\n    </div>\r\n</section>");


        }
    }
}
#pragma warning restore 1591
