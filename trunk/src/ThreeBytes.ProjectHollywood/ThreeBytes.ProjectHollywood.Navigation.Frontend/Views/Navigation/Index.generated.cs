﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThreeBytes.ProjectHollywood.Navigation.Frontend.Views.Navigation
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Navigation/Index.cshtml")]
    public class Index : System.Web.Mvc.WebViewPage<ThreeBytes.ProjectHollywood.Navigation.Frontend.Models.NavigationViewModel>
    {
        public Index()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\Views\Navigation\Index.cshtml"
Write(Html.RenderNavigation(Model.Navigation));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");


            
            #line 5 "..\..\Views\Navigation\Index.cshtml"
   
  using (Html.BeginScriptContext())
  {
    Html.AddScriptBlock(@"
        jQuery(document).ready(function() {
            $('#topbar').dropdown();
        });");
  }

            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
