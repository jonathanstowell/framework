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

namespace ThreeBytes.User.Role.Host.Frontend.Views.RoleHost
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
    using ThreeBytes.User.Role.Host.Resources;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/RoleHost/Index.cshtml")]
    public class Index : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Index()
        {
        }
        public override void Execute()
        {

            
            #line 1 "..\..\Views\RoleHost\Index.cshtml"
  
    ViewBag.Title = Resources.BrowserTitle;


            
            #line default
            #line hidden
WriteLiteral("\r\n<section id=\"user-role-home\">\r\n    <div class=\"row\">\r\n        <div class=\"span1" +
"2 columns\">\r\n\r\n");


            
            #line 9 "..\..\Views\RoleHost\Index.cshtml"
             if (((ThreeBytesPrincipal) Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "EmailTemplateManager" }))
            {
                { Html.RenderAction("Create", "RoleManagement"); }
            }

            
            #line default
            #line hidden
WriteLiteral("            \r\n");


            
            #line 14 "..\..\Views\RoleHost\Index.cshtml"
               Html.RenderAction("List", "RoleList"); 

            
            #line default
            #line hidden
WriteLiteral("       \r\n        </div>\r\n        \r\n");


            
            #line 18 "..\..\Views\RoleHost\Index.cshtml"
         if (((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "EmailTemplateManager" }))
        {
            { Html.RenderAction("Edit", "RoleManagement"); }
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 23 "..\..\Views\RoleHost\Index.cshtml"
           Html.RenderAction("Details", "RoleView");

            
            #line default
            #line hidden
WriteLiteral("                 \r\n    </div>\r\n</section>");


        }
    }
}
#pragma warning restore 1591
