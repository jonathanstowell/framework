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

namespace ThreeBytes.ProjectHollywood.Notification.News.Frontend.Views.NotificationNews
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
    
    #line 1 "..\..\Views\NotificationNews\Index.cshtml"
    using ThreeBytes.Core.Security.Concrete;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.2.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/NotificationNews/Index.cshtml")]
    public class Index : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Index()
        {
        }
        public override void Execute()
        {

WriteLiteral("\r\n");


            
            #line 3 "..\..\Views\NotificationNews\Index.cshtml"
 if (Context.User.Identity.IsAuthenticated && ((ThreeBytesPrincipal)Context.User).IsInAnyRoles(new[] { "Creator", "Admin", "NewsManager" }))
{
    using (Html.BeginScriptContext())
    {
        Html.AddScriptBlock(@"

        var notification_news = {};

        (function (index) {
            
            notification_news = index;

            var hub = jQuery.connection.notificationNewsHub;

            hub.handleNotification = function(id, title, message) {
                jQuery(document).trigger('publishNotification', [id, title, message]);
            };

        } (notification_news));");
    }
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
