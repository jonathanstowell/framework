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

namespace ThreeBytes.User.Authentication.OAuth.Frontend.Views.Foursquare
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Foursquare/Index.cshtml")]
    public class Index : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Index()
        {
        }
        public override void Execute()
        {
WriteLiteral("<a href=\"");


            
            #line 1 "..\..\Views\Foursquare\Index.cshtml"
    Write(Url.Action("Login", "Foursquare"));

            
            #line default
            #line hidden
WriteLiteral("\"><img src=\"");


            
            #line 1 "..\..\Views\Foursquare\Index.cshtml"
                                                  Write(Url.Content("~/img/foursquare_64.png"));

            
            #line default
            #line hidden
WriteLiteral("\"/></a>");


        }
    }
}
#pragma warning restore 1591
