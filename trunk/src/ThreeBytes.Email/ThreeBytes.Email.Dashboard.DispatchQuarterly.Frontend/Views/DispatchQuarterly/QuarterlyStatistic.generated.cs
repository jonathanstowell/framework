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

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Frontend.Views.DispatchQuarterly
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
    using System.Web.Script.Serialization;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using ThreeBytes.Core.Extensions.Mvc;
    using ThreeBytes.Email.Dashboard.DispatchQuarterly.Frontend.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/DispatchQuarterly/QuarterlyStatistic.cshtml")]
    public class QuarterlyStatistic : System.Web.Mvc.WebViewPage<DispatchStatisticViewModel>
    {
        public QuarterlyStatistic()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n<div id=\"quarterly-email-dispatch-statistics-container\" class=\"stat\">\r\n    <h4>" +
"Dispatched Emails This Quarter</h4>\r\n    <span class=\"value\">");


            
            #line 5 "..\..\Views\DispatchQuarterly\QuarterlyStatistic.cshtml"
                   Write(Model.CurrentStatistic);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n</div>");


        }
    }
}
#pragma warning restore 1591
