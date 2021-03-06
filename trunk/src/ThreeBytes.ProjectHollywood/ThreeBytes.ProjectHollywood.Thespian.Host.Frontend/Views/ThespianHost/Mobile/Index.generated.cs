﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThreeBytes.ProjectHollywood.Thespian.Host.Frontend.Views.ThespianHost.Mobile
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ThespianHost/Mobile/Index.cshtml")]
    public class Index : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Index()
        {
        }
        public override void Execute()
        {

            
            #line 1 "..\..\Views\ThespianHost\Mobile\Index.cshtml"
  
    ViewBag.Id = "our-clients-page";


            
            #line default
            #line hidden
WriteLiteral("\r\n");


DefineSection("Header", () => {

WriteLiteral("\r\n    <h1>Our Clients</h1>\r\n");


});

WriteLiteral("\r\n\r\n");


            
            #line 10 "..\..\Views\ThespianHost\Mobile\Index.cshtml"
   Html.RenderAction("List", "ThespianList"); 

            
            #line default
            #line hidden
WriteLiteral("\r\n");


DefineSection("OtherPages", () => {

WriteLiteral("\r\n");


            
            #line 14 "..\..\Views\ThespianHost\Mobile\Index.cshtml"
       Html.RenderAction("Details", "ThespianView");

            
            #line default
            #line hidden

});

WriteLiteral("\r\n\r\n");


            
            #line 17 "..\..\Views\ThespianHost\Mobile\Index.cshtml"
   
    using (Html.BeginScriptContext())
    {
        Html.AddScriptBlock(@"

        var thespian_host  = {};

        (function (index) {

            thespian_host = index;

            jQuery(document).bind('thespianHost', function (event) {
                jQuery.mobile.changePage('#our-clients-page', {
	                transition: 'flow',
	                reverse: false,
	                changeHash: false
                });
            });

        } (thespian_host));");
    }


            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
